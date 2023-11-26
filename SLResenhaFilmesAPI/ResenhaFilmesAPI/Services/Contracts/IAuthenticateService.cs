namespace ResenhaFilmesAPI.Services.Contracts
{
    //implemetação do  meu serviço de Autheticação
    public interface IAuthenticateService
    {
        //contrato para fazer o login e logout

        //vou definir uma assinatura de método Authenticate  onde o usuário vai informar o login e a senha. Definido uma classe Task definido que vai ser uma operção assincrona
        //vá para classe AuthenticateService
        Task<bool> Authenticate(string userName, string password);

        //Registro do usuário para que ele possa ser validado e gerar um token
        Task<bool> Register(string userName, string password);

        Task Logout();
    }
}
