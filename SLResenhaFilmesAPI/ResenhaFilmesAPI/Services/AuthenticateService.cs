using Microsoft.AspNetCore.Identity;
using ResenhaFilmesAPI.Services.Contracts;
using System.Runtime.InteropServices;

namespace ResenhaFilmesAPI.Services
{
    //Essa class implenta a nossa Interface IAuthenticateService
    // 1° passo Para fazer a implemetação da Autenticação vamos usar os recurso do Identity
    public class AuthenticateService : IAuthenticateService
    {
        //3° Passo  usar um recurso do Identity para fazer a autenticação do usuário usando a class
        //SignInManager  é uma instância dessa classe e vai ser injetada no construtor
        private readonly SignInManager<IdentityUser> _signInManager;

        //UserManager  é uma instância dessa classe e vai ser injetada no construtor
        private readonly UserManager<IdentityUser> _userManager;

        //2° Passo criar um construtor
        public AuthenticateService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            //atribuindo a instâcia recebida a _signInManager
            _signInManager = signInManager;

            _userManager = userManager;
        }

        //4° Implementar os métodos
        public async Task<bool> Authenticate(string userName, string password)
        {
            //5° criar  declarar uma variáve var result passando uma instâcia  _signInManager
            //acessando o método PasswordSignInAsync(userName, password, infomando se cokie de entradaseja persistido depois que o navagador for fechado false,  lockoutOnFailure: false definindo um outro argumento que a conta do usuário seja bloqueada se a  conexão falhar) 
            var result = await _signInManager.PasswordSignInAsync(userName, password, false,
                lockoutOnFailure: false);

            //¨6° caso retornar se foi verdadeiro ou false
            //se o usuário conseguiu fazer o login com sucesso vai retornar true caso não false
            return result.Succeeded;
        }

        //6 Passo implementar o registro do usuário para que ele possa ser validado e gerar o token
        public async Task<bool> IAuthenticateService.Register(string userName, string password)
        {
            //criar uma instância do meu IdentityUser
            var user = new IdentityUser
            {
                //atribuindo o userame ao userName
                UserName = userName,
               
            };

            //usando um result com uma instância do userManager acessando o método CreateAsync passando o user e a senha

            var result = await _userManager.CreateAsync(user, password);

            //verificar se o usuário foi criado com sucesso
            if (result.Succeeded)
            {
                //se criado com sucesso chamamos o _signInManager passando o usuário user, passando um argumento isPersistent: false indicando que e não é 
                //necessario que o cookie de login persita após o navegador fechar
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            //retorna um result indicando se a operação foi feita com sucesso
            return result.Succeeded;
        }

        //7° Passo implementar o Logout usando o método SingnOutAsync
        //vá para program.cs registar esse serviço
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
