namespace FilePracticum.FileManager
{
    public class NotesAppender : FileOperation
    {
        private readonly string _note;

        public NotesAppender(string filePath, string note) : base(filePath)
        {
            _note = note;
        }

        protected override void PerformOperation()
        {
            File.AppendAllText(_filePath, _note + Environment.NewLine);
            Console.WriteLine($"Заметка добавлена в {_filePath}");
        }
    }
}
