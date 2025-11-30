class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int maxNumber = int.MinValue;

        Console.WriteLine("Вводите числа. Вводите 'exit' для завершения.");
        Console.WriteLine("Введены не числа будут проигнорированы с предупреждением.\n");

        while (true)
        {
            Console.Write("Введите число: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));
            if (input.ToLower() == "exit")
            {
                break;
            }

            try
            {
                int number = int.Parse(input);
                numbers.Add(number);

                if (number > maxNumber)
                    maxNumber = number;

                Console.WriteLine($"Число принято. Максимум пока: {maxNumber}\n");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Предупреждение: '{input}' не является числом. " +
                                $"Введите корректное целое число.\n");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Предупреждение: '{input}' выходит за пределы диапазона int. " +
                                $"Введите число от {int.MinValue} до {int.MaxValue}.\n");
            }
        }

        if (numbers.Count > 0)
        {
            Console.WriteLine($"\nРезультаты:");
            Console.WriteLine($"Всего чисел введено: {numbers.Count}");
            Console.WriteLine($"Максимальное число: {maxNumber}");
        }
        else
        {
            Console.WriteLine("\nНикаких корректных чисел введено не было.");
        }
    }
}
