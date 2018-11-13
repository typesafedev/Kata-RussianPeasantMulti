namespace RussianPeasantMultiplication
{
    using System;
    using System.Collections.Generic;
    using static System.Console;
    using static System.Math;

    //Russian peasant multiplication written in a more functional style - hylomorphism lite
    //https://maartenfokkinga.github.io/utwente/mmf91m.pdf
    //Implementing peasant multiplication using true hylomorphism involves implementing an "algebra" seperate from the Fold and Unfold combinators unlike this implementation. 
    public static class Functional
    {
        private static IEnumerable<(int x, int y)> Unfold(int x, int y, Action<int, int> print)
        {
            while (true)
            {
                print(x, y);
                if (y == 0) { yield break; }
                yield return (x, y);
                x *= 2;
                y /= 2;
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

            //Normalize
            if (x > 0 == y > 0) { return Abs(product); }

            return -Abs(product);
        }
    }
}