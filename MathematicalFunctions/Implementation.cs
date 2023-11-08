using System.Dynamic;
using System.Runtime.ExceptionServices;
using System.Transactions;

namespace MathematicalFunctions
{
    public class Implementation
    {
        public static double Sqrt(uint number)
        {
            double sqrt = 0;
            List<decimal> primeFactors = new();
            if (number % 2 == 0)
            {
                primeFactors.Add(2);
                sqrt += 2;
            }
            while (number >= 1)
            {
                uint lowestValue = 0;
                for (uint i = 10; i > 1; i--)
                {
                    if (number % i == 0)
                    {
                        lowestValue = i;
                    }
                }
                if (lowestValue == 0) {
                    break;
                }
                // todo div by 0
                number /= lowestValue;
                if (number != 1)
                {

                }
                primeFactors.Add(lowestValue);
                sqrt += lowestValue;
                Console.WriteLine("HighestValue: {0}, remainder: {1}", lowestValue, number);
            }


            //sqrt += highestValue / multiplier;
            Console.WriteLine("Remainder: {0}", number);
            return sqrt;
        }
        private static double Factorial(double number)
        {
            double factorial = 1;
            while (number > 0)
            {
                factorial *= number;
                number -= 1;
            }
            return factorial;
        }
        public static double Sin(double number)
        {
            double sin = number;
            for (int i = 3; i < 40; i += 2)
            {
                if ((i - 1) % 4 == 0)
                {
                    sin += Math.Pow(number, i) / Factorial(i);
                }
                else
                {
                    sin -= Math.Pow(number, i) / Factorial(i);
                }
            }
            if (Math.Round(sin, 2) * 2 % 1 == 0) // so that 0, 0.5, 1, etc. are whole numbers
            {
                return Math.Round(sin, 2);
            }
            else
            {
                return sin;
            }
        }
        public static double Cos(double number)
        {
            double cos = 1;
            for (int i = 2; i < 40; i += 2)
            {
                if (i % 4 == 0)
                {
                    cos += Math.Pow(number, i) / Factorial(i);
                }
                else
                {
                    cos -= Math.Pow(number, i) / Factorial(i);
                }
            }
            if (Math.Round(cos, 2) * 2 % 1 == 0) // so that 0, 0.5, 1, etc. are whole numbers
            {
                return Math.Round(cos, 2);
            }
            else
            {
                return cos;
            }
        }
    }
}