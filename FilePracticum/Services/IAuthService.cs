namespace FilePracticum.Services
{
    public interface IAuthService
    {
        bool Authenticate(string login, string password);
        void SaveCredentials(string login, string password);
    }
}
