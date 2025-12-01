namespace FilePracticum.Config
{
    public sealed class FileConfig
    {
        private static readonly FileConfig instance = new();
        private FileConfig() { }

        public static FileConfig Instance => instance;

        public string AuthFile => "auth.txt";
        public string NotesFile => "notes.txt";
        public string TextFile => "text.txt";
    }
}
