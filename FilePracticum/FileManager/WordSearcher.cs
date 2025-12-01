namespace FilePracticum.FileManager
{
    public class WordSearcher : FileOperation
    {
        private readonly string _searchWord;

        public WordSearcher(string filePath, string searchWord) : base(filePath)
        {
            _searchWord = searchWord;
        }

        protected override void PerformOperation()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"Файл {_filePath} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(_filePath);
            var matchingLines = lines.Where(line => line.IndexOf(_searchWord, StringComparison.OrdinalIgnoreCase) >= 0);

            Console.WriteLine($"Найдено строк с '{_searchWord}':");
            foreach (string line in matchingLines)
            {
                Console.WriteLine(line);
            }

            if (!matchingLines.Any())
            {
                Console.WriteLine("Строки не найдены.");
            }
        }
    }
}
