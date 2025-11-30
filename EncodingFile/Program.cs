using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        string filePath = "test_file.txt";
        string content = "Привет! Это текст на русском языке.";
        try
        {
            File.WriteAllText(filePath, content, Encoding.UTF8);
            Console.WriteLine("Файл создан в кодировке UTF-8");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при создании файла: {e.Message}");
            return;
        }

        try
        {
            string readContent = File.ReadAllText(filePath, Encoding.GetEncoding(1251));
            Console.WriteLine("\nСодержимое (прочитано как CP1251):");
            Console.WriteLine(readContent);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Ошибка при чтении файла: {e.Message}");
        }
        catch (DecoderFallbackException e)
        {
            Console.WriteLine($"Ошибка декодирования (CP1251 несовместима с UTF-8): {e.Message}");
        }

        try
        {
            string readContentUTF8 = File.ReadAllText(filePath, Encoding.UTF8);
            Console.WriteLine("\nСодержимое (прочитано как UTF-8):");
            Console.WriteLine(readContentUTF8);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
        }

        try
        {
            File.Delete(filePath);
            Console.WriteLine("\nВременный файл удалён");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при удалении: {e.Message}");
        }
    }
}
