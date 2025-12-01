namespace FilePracticum.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _authFile;

        public AuthService(string authFile)
        {
            _authFile = authFile;
        }

        public bool Authenticate(string login, string password)
        {
            try
            {
                if (!File.Exists(_authFile))
                    return false;

                string[] lines = File.ReadAllLines(_authFile);
                if (lines.Length < 2)
                    return false;

                return lines[0].Trim() == login && lines[1].Trim() == password;
            }
            catch
            {
                return false;
            }
        }

        public void SaveCredentials(string login, string password)
        {
            try
            {
                File.WriteAllLines(_authFile, new[] { login, password });
                Console.WriteLine($"Учетные данные сохранены в {_authFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}
