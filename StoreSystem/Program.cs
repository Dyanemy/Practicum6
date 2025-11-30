class Program
{
    static void Main()
    {
        int countBunOnStock = 60;

        Console.WriteLine($"На складе: {countBunOnStock} булочек");
        Console.Write("Сколько булочек заказал покупатель? ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));
        if (!int.TryParse(input, out int countBunOnOrder))
        {
            throw new FormatException("Ошибка! Введите корректное целое число.");
        }   
        else if (countBunOnOrder <= 0)
        {
            throw new ArgumentException("Ошибка! Количество булочек должно быть больше 0.");
        }
        else if (countBunOnOrder > countBunOnStock)
        {
            Console.WriteLine($"ОШИБКА! На складе только {countBunOnStock} булочек, " +
                            $"а заказано {countBunOnOrder}.");
            Console.WriteLine($"Продаём максимально возможное количество: {countBunOnStock} булочек");
            countBunOnStock = 0;
        }
        else
        {
            countBunOnStock -= countBunOnOrder;
            Console.WriteLine($"Продано {countBunOnOrder} булочек");
        }

        Console.WriteLine($"На складе осталось: {countBunOnStock} булочек");
    }
}
