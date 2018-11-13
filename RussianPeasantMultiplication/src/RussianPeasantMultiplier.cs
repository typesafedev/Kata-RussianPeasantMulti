﻿namespace RussianPeasantMultiplication
{
    using System;
    using System.Collections.Generic;

    public class RussianPeasantMultiplier
    {
        private readonly bool logSteps;

        /// <summary>
        /// X1 value of the last multiplication
        /// </summary>
        public int X1 { get; set; }

        /// <summary>
        /// X2 value of the last multiplication
        /// </summary>
        public int X2 { get; set; }

        /// <summary>
        /// Steps taken in the last multiplication
        /// </summary>
        public IDictionary<int, int> Steps { get; set; }

        public RussianPeasantMultiplier()
            : this(false)
        {
        }

        public RussianPeasantMultiplier(bool logSteps)
        {
            this.logSteps = logSteps;
        }

        public int Multiply(int x1, int x2)
        {
            this.SetValues(x1, ref x2);

            return this.CheckAndNegate(
                this.RussianMultiply(this.X1, this.X2));
        }

        private int RussianMultiply(int x1, int x2)
        {
            this.LogStep(x1, x2);

            if (x1 == 0)
            {
                return 0;
            }

            if (Math.Abs(x1) == 1)
            {
                return x2;
            }

            // Uncomment to induce a bug
            //if (x1 > 1000 && x1 < 10000)
            //    return 42;

            if (x1 % 2 != 0)
            { // x1 is odd so use x2 in sum to result and get next value
                return x2 + this.RussianMultiply(x1 / 2, x2 * 2);
            }

            // x1 is even so don't use x2 in sum, just get the next value
            return this.RussianMultiply(x1 / 2, x2 * 2);



        }

        private void LogStep(int x1, int x2)
        {
            if (this.logSteps)
            {
                this.Steps.Add(x1, x2);
            }
        }

        /// <summary>
        /// CheckAndNegate - if x1 is negative then negate the result
        /// </summary>
        /// <param name="result">int - result of the russian peasant multiplication</param>
        /// <returns>int - result negated if x1 is negative</returns>
        private int CheckAndNegate(int result)
        {
            if (this.X1 < 0)
            {
                result = result * -1;
            }
            return result;
        }

        /// <summary>
        /// SetValues - sets the current values of the multiplier
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        private void SetValues(int x1, ref int x2)
        {
            this.Steps = new Dictionary<int, int>();

            if (Math.Abs(x1) > Math.Abs(x2))
            {
                this.X1 = x2;
                this.X2 = x1;
            }
            else
            {
                this.X1 = x1;
                this.X2 = x2;
            }
        }

    }
}