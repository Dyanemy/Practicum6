class Program
{
    static void Main()
    {
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b;
            Console.WriteLine($"Результат: {result}");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Ошибка: {e.Message}");
            Console.WriteLine("Результат: 0");
        }
    }
}
