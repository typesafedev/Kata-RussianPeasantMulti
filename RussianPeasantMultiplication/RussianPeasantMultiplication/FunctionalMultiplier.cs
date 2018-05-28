namespace RussianPeasantMultiplication
{
    using System;
    using System.Collections.Generic;
    using static System.Console;
    using static System.Math;

    //Russian peasant multiplication wriiten in more functional style.
    public static class Functional
    {
        private static IEnumerable<(int x, int y)> Unfold(int x, int y, Action<int, int> print)
        {
            var x1 = x;
            var y1 = y;

            while (true)
            {
                print(x1, y1);
                if (y1 == 0) { yield break; }
                yield return (x1, y1);
                x1 *= 2;
                y1 /= 2;
            }
        }

        private static int Fold(IEnumerable<(int x, int y)> terms, Action<int> print)
        {
            var acc = 0;
            foreach (var (x, y) in terms)
            {
                //sum only if y is odd
                if (y % 2 != 0) { acc += x; }
            }
            print(acc);
            return acc;
        }

        private static void Print(int x, int y)
        {
            if (y % 2 == 0) { ForegroundColor = ConsoleColor.Red; }
            else { ForegroundColor = ConsoleColor.Green; }

            WriteLine($"{x} {y}");
        }

        private static void Print(int product)
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine($"\nResult = {product}");
        }

        public static int Multiply(int x, int y)
        {
            var products = Unfold(x, y, Print);
            var product = Fold(products, Print);

            //Normalize product
            if (x > 0 == y > 0) { return Abs(product); }

            return -Abs(product);
        }

    }
}