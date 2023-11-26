
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ResenhaFilmesAPI.Context;
using ResenhaFilmesAPI.Repositories;
using ResenhaFilmesAPI.Repositories.Contracts;
using ResenhaFilmesAPI.Service.Contracts;
using ResenhaFilmesAPI.Services;
using ResenhaFilmesAPI.Services.Contracts;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);




var key  = Encoding.ASCII.GetBytes(ResenhaFilmesAPI.Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(x => { 

    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {

       ValidateIssuerSigningKey = true,
       IssuerSigningKey = new SymmetricSecurityKey(key),
       ValidateIssuer = false,
       ValidateAudience = false

    };



});

//Registrando o Context e definindo o provedor de banco de dados que esta sendo usado no caso o MySql e a string de conexão com o banco de dados
string mySqlConnection = builder.Configuration.GetConnectionString("mysqlDbConexao");
var versaoServer = ServerVersion.AutoDetect(mySqlConnection);

//incluimos um referência ao contexto e o provedor do banco de dados ultilizando a string de conexão criada appSenttings.json
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnection, versaoServer));




#region mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region servicos

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IResenhaRepository, ResenhaRepository>();
builder.Services.AddScoped<IResenhaService, ResenhaService>();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
//informa a classe e informa a implemetação toda vez que referênciar a interface o container vai me dar uma instâcia da implemetação.
//registrado o serviço criado para Autenticar o usuário
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();


#endregion


// Add services to the container.
builder.Services.AddControllers();

//Depois do AppDbContext
//O método AddIdentity adiciona a configuração padrão para os tipos IdentityUser e para o IdentityRole que representa os perfis do usuàrio
//IdentityUser é uma classe que vai conter as propriedades do usuário que vai se Autenticar 
//AddEntityFrameworkStores usado para armazenar e recuperar dados do usuário e dos perfis do usuário que foram registrados. EntityFrameworkCore no MySql necessario definir o contexto
//recurso usado para gerar token nas operações de conta do usuário como recuperação de senha ou
//alteração do email que utilizado na autenticação de 2 fatores
//Vá par IAutheticate.cs
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apiagenda", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//apartir da onde vão ser feitas as requisições
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

