/// <summary>
/// В .NET (C#) исключение StackOverflowException приводит к краху CLR быстрее чем успевает отработать catch. 
/// Следовательно приходится использовать другой способ решения задачи.
/// </summary>

class Program
{
    private const int MAX_RECURSION_DEPTH = 5000;

    static void SafeRecursion(int depth = 0)
    {
        if (depth >= MAX_RECURSION_DEPTH)
            throw new InvalidOperationException(
                $"Обнаружена потенциальная бесконечная рекурсия! " +
                $"Глубина: {depth}/{MAX_RECURSION_DEPTH}");

        Console.WriteLine($"Глубина рекурсии: {depth}");
        SafeRecursion(depth + 1);
    }

    static void Main()
    {
        try
        {
            SafeRecursion();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"\n{e.Message}");
            Console.WriteLine("✓ Рекурсия безопасно остановлена");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Неожиданная ошибка: {e.GetType().Name}: {e.Message}");
        }

        Console.WriteLine("\nПрограмма продолжает работать нормально");
    }
}
