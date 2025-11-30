class Program
{
    static void Main()
    {
        string? number = Console.ReadLine();
        if (string.IsNullOrEmpty(number)) throw new ArgumentNullException(nameof(number));
        if (!int.TryParse(number, out _))
            throw new FormatException("Введена некорректная строка - ожидается целое число");

        Console.WriteLine("выполняем расчеты...");
    }
}
