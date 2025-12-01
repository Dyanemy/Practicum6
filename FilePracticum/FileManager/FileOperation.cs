namespace FilePracticum.FileManager
{
    public abstract class FileOperation
    {
        protected readonly string _filePath;

        protected FileOperation(string filePath)
        {
            _filePath = filePath;
        }

        public void Execute()
        {
            try
            {
                PerformOperation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка операции с файлом: {ex.Message}");
            }
        }

        protected abstract void PerformOperation();
    }
}
