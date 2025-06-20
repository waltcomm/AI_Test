using System;
using System.Globalization;

namespace AI_Test
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("===== IT Sistēmas pieteikuma forma =====");

            Console.Write("Sistēma vai modulis: ");
            string system = Console.ReadLine()?.Trim();

            Console.Write("Apraksts: ");
            string description = Console.ReadLine()?.Trim();

            Console.Write("Soļi, kā atkārtot problēmu (nav obligāti): ");
            string steps = Console.ReadLine()?.Trim();

            Console.Write("Sagaidāmais rezultāts: ");
            string expectedResult = Console.ReadLine()?.Trim();

            Console.Write("Prioritāte (zema / vidēja / augsta): ");
            string priority = Console.ReadLine()?.Trim().ToLower();

            var request = new ApplicationRequest
            {
                SystemOrModule = system,
                Description = description,
                Steps = steps,
                ExpectedResult = expectedResult,
                Priority = priority
            };

            var ai = new AIProcessor();

            try
            {
                request.Title = ai.GenerateTitle(request);
                request.Type = ai.DetermineType(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Kļūda, izmantojot AI: {ex.Message}");
                return;
            }

            if (request.Type.ToLower().Contains("neattiecas"))
            {
                Console.WriteLine("\nPieteikums neattiecas uz informācijas sistēmu.");
                return;
            }

            Console.WriteLine("\n===== Pieteikuma kopsavilkums =====");
            Console.WriteLine($"Nosaukums: {request.Title}");
            Console.WriteLine($"Tips: {request.Type}");
            Console.WriteLine($"Prioritāte: {priority}");
        }
    }

    public class ApplicationRequest
    {
        public string SystemOrModule { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string ExpectedResult { get; set; }
        public string Priority { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
