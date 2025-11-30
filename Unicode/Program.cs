class Program
{
    static void Main()
    {
        try
        {
            char character = 'V';
            int code = (int)character;
            Console.WriteLine($"Код символа '{character}': {code}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка в ord: {e.Message}");
        }

        Console.WriteLine();
        try
        {
            int code = 566556656;
            if (code < 0 || code > 0x10FFFF)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(code),
                    $"Код {code} выходит за пределы допустимого диапазона Unicode (0 - 0x10FFFF)");
            }

            char character = (char)code;
            Console.WriteLine($"Символ по коду {code}: '{character}'");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Ошибка в chr: {e.Message}");
            char fallback = '?';
            Console.WriteLine($"Возвращаем символ замены: '{fallback}'");
            Console.WriteLine($"Результат: '{fallback}'");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Неожиданная ошибка: {e.Message}");
        }
    }
}
