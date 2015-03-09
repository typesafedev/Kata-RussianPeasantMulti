namespace RussianPeasantMultiplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class Program
    {
        private static RussianPeasantMultiplier russianPeasantMultiplier;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Russian Peasant Multiplier!");

            var showSteps = GetYesNo("Would you like to see the steps? (y/n) ");

            russianPeasantMultiplier = new RussianPeasantMultiplier(showSteps);

            while (true)
            {
                if (!DoTheMultiplication(showSteps))
                {
                    break;
                }
            }

            Console.ReadLine();
        }

        private static bool DoTheMultiplication(bool showSteps)
        {
            var x1 = GetValue("first value");
            var x2 = GetValue("second value");

            Console.WriteLine("Multiplying {0} and {1} using Russian peasant multiplication", x1, x2);

            var result = russianPeasantMultiplier.Multiply(x1, x2);

            if (showSteps)
            {
                ShowSteps(russianPeasantMultiplier.Steps);
            }

            Console.WriteLine("Result: {0}", result);

            return GetYesNo("Do another multiplication? (y/n) ");
        }

        private static void ShowSteps(IDictionary<int, int> steps)
        {
            Pause();
            WriteSteps(steps);
            Pause();
            WriteOddEven(steps);
            Pause();
            WriteSum(steps);
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Thread.Sleep(750);
        }

        private static void WriteSteps(IDictionary<int, int> steps)
        {
            foreach (var step in steps)
            {
                WriteStep(step);
                Thread.Sleep(350);
            }
        }

        private static void WriteOddEven(IDictionary<int, int> steps)
        {
            foreach (var step in steps)
            {
                Console.ForegroundColor = step.Key % 2 != 0 
                    ? ConsoleColor.Green 
                    : ConsoleColor.Red;

                WriteStep(step);
                Console.ResetColor();
            }
        }

        private static void WriteSum(IDictionary<int, int> steps)
        {
            var i = 0;

            foreach (var oddStep in steps.Where(s => s.Key % 2 != 0))
            {
                Console.WriteLine("\t {0}", oddStep.Value);
                if (++i < steps.Count(s => s.Key % 2 != 0))
                {
                    Console.Write("+");
                }
            }
        }

        private static void WriteStep(KeyValuePair<int, int> step)
        {
            Console.WriteLine("{0} \t {1}", step.Key, step.Value);
        }

        private static int GetValue(string identifier)
        {
            int value;
            string line;
            do
            {
                Console.Write("Enter {0}: ", identifier);
                line = Console.ReadLine();
            }
            while (!int.TryParse(line, out value));

            return value;
        }

        private static bool GetYesNo(string question)
        {
            Console.Write(question);
            var showSteps = Console.ReadKey().KeyChar == 'y';
            Console.WriteLine();
            return showSteps;
        }
    }
}
