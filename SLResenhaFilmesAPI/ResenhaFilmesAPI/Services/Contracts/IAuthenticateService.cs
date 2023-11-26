namespace ResenhaFilmesAPI.Services.Contracts
{
    //implemetação do  meu serviço de Autheticação
    public interface IAuthenticateService
    {
        //contrato para fazer o login e logout

        //vou definir uma assinatura de método Authenticate  onde o usuário vai informar o login e a senha. Definido uma classe Task definido que vai ser uma operção assincrona
        Task<bool> Authenticate(string username, string password);

        Task Logout();
    }
}
