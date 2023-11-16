using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResenhaFilmesAPI.Context;


var builder = WebApplication.CreateBuilder(args);


//Pegando a String de conexeção com o banco de Dados criada no appsettings.json
string mySqlConnection = builder.Configuration.GetConnectionString("mysqlDbConexao");

//Registrando o context passando as intruções do banco passando a versão do banco
 var versaoServer = ServerVersion.AutoDetect(mySqlConnection);

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySql(mySqlConnection, versaoServer));

#region mapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion


// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
