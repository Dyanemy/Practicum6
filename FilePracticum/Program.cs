using FilePracticum.Config;
using FilePracticum.FileManager;
using FilePracticum.Services;

namespace FileOperationsApp
{
    // Фасад для всех операций (для удобства)
    public class FileOperationsFacade
    {
        private readonly IAuthService _auth;
        private readonly FileConfig _config;

        public FileOperationsFacade()
        {
            _config = FileConfig.Instance;
            _auth = new AuthService(_config.AuthFile);
        }

        public void InitializeData()
        {
            if (!File.Exists(_config.NotesFile))
            {
                File.WriteAllText(_config.NotesFile, "Заметка 1" + Environment.NewLine);
            }

            if (!File.Exists(_config.TextFile))
            {
                File.WriteAllText(_config.TextFile,
                    "Привет, мир!" + Environment.NewLine +
                    "Мир прекрасен." + Environment.NewLine);
            }
        }

        public void InitializeAuth()
        {
            Console.WriteLine("=== Инициализация учетных данных ===");
            Console.Write("Введите логин (пример: user): ");
            string login = Console.ReadLine()!;
            Console.Write("Введите пароль (пример: 1234): ");
            string password = Console.ReadLine()!;

            _auth.SaveCredentials(login, password);
        }

        public bool PerformAuth()
        {
            Console.WriteLine("\n=== Авторизация ===");
            Console.Write("Введите логин: ");
            string login = Console.ReadLine()!;
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine()!;

            bool success = _auth.Authenticate(login, password);
            if (success)
            {
                Console.WriteLine("Авторизация успешна!");
            }
            else
            {
                Console.WriteLine("Ошибка авторизации!");
            }
            return success;
        }

        public void AddNote()
        {
            Console.WriteLine("\n=== Добавление заметки ===");
            Console.Write("Введите заметку: ");
            string note = Console.ReadLine()!;

            var appender = new NotesAppender(_config.NotesFile, note);
            appender.Execute();
        }

        public void SearchWord()
        {
            Console.WriteLine("\n=== Поиск слова ===");
            Console.Write("Введите искомое слово: ");
            string word = Console.ReadLine()!;

            var searcher = new WordSearcher(_config.TextFile, word);
            searcher.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var facade = new FileOperationsFacade();
            facade.InitializeAuth();
            var resultAuth = facade.PerformAuth();
            if (resultAuth)
            {
                facade.InitializeData();
                facade.AddNote();
                facade.SearchWord();
            }
        }
    }
}
