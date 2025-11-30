class Program
{
    static void Main()
    {
        Dictionary<string, int[]> dictPlanetTemp = new()
        {
            { "Tino_1", new int[] { -120, 300 } },
            { "Tino_2", new int[] { -12, 7500 } },
            { "Tino_3", new int[] { -1, 3 } },
            { "Tino_4", new int[] { -10, 0 } },
            { "Tino_5", new int[] { -140, 60 } },
            { "Tino_6", new int[] { -35, 33 } }
        };

        Dictionary<string, int[]> canLifePlanet = [];

        const int MIN_TEMP = -50;
        const int MAX_TEMP = 70;
        const string OK = "Пригодна для жизни";
        const string NO = "НЕ пригодна";
        Console.WriteLine("Доступные планеты:");
        foreach (var planet in dictPlanetTemp)
        {
            int minPlanet = planet.Value[0];
            int maxPlanet = planet.Value[1];
            string status = CanSustainLife(minPlanet, maxPlanet, MIN_TEMP, MAX_TEMP) ? OK : NO;
            if (status == OK)
            {
                canLifePlanet.Add(planet.Key, planet.Value);
            }

            Console.WriteLine($"{planet.Key}: [{minPlanet}, {maxPlanet}] - {status}");
        }

        Console.WriteLine("\nВведите НОМЕР планеты (цифра в названии):");
        string? planetNumber = Console.ReadLine();
        if (string.IsNullOrEmpty(planetNumber)) throw new ArgumentNullException(nameof(planetNumber));
        string planetKey = "Tino_" + planetNumber;
        if (!canLifePlanet.ContainsKey(planetKey))
        {
            int[] temps = dictPlanetTemp[planetKey];
            throw new InvalidOperationException(
                $"ОШИБКА! Планета {planetKey} НЕ пригодна для жизни! " +
                $"Температурный диапазон [{temps[0]}, {temps[1]}] не совместим с жизнью. " +
                $"Требуемый диапазон: [{MIN_TEMP}, {MAX_TEMP}]");
        }

        Console.WriteLine($"Приземляемся на {planetKey}.... ");
        Console.WriteLine("Зонд приземлился");
    }

    /// <summary>
    /// Проверяет, может ли планета поддерживать жизнь
    /// Жизнь возможна, если диапазон температур планеты пересекается с диапазоном жизни
    /// </summary>
    static bool CanSustainLife(int minPlanet, int maxPlanet, int minLife, int maxLife) =>
         (maxPlanet < maxLife && minPlanet > minLife);
}
