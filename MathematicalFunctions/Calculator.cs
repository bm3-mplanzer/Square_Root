using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace MathematicalFunctions
{
    public class Calculator
    {
        public static string EvaluateExpression(string expression)
        {
            // trims spaces around operators, but not between numbers: "1. 1 / .2 " => "1. 1/.2"
            expression = expression.Replace(" ", "");
            //expression = (new Regex("(\\s(?=[^0-9._]))|((?<=[^0-9._])\\s)")).Replace(expression.ToLower().Trim(), "");
            var SimpleOperation = @"(_?\d+\.?\d*){1}{0}{1}(_?\d+\.?\d*){1}";
            
            int i;
            while ((i = expression.IndexOf('(')) != -1) {
                int iOrig = i;
                string before = expression.Substring(0, i);
                string parenthesis = "";
                while (expression[i] != ')')
                { // expression.Length < i &&  
                    i++;
                    if (expression[i] == '(')
                    {
                        before += expression.Substring(iOrig, i - iOrig);
                        parenthesis = "";// expression[i].ToString();
                    }
                    parenthesis += expression[i];
                }
                if (parenthesis.EndsWith(')')) {
                     parenthesis = parenthesis.Substring(0, parenthesis.Length - 1);
                }
                if (parenthesis.StartsWith('('))
                {
                    parenthesis = parenthesis.Substring(1, parenthesis.Length-1);
                }
                string after = expression.Substring(i + 1);
                expression = before + EvaluateExpression(parenthesis) + after;
            }
#if false
            foreach (var currentOp in "^*/+-")
            {
                var currentRegEx = new Regex(string.Format(SimpleOperation, currentOp, "{1}"));
                while (currentRegEx.IsMatch(expression))
                {
                    Match match = currentRegEx.Match(expression);
                    string num1 = match.Groups[1].Value;
                    string op = match.Groups[2].Value;
                    string num2 = match.Groups[3].Value;

                    string before, after, result;
                    before = expression.Substring(0, match.Index);
                    after = expression.Substring(match.Index + match.Length);
                    result = PerformOperation(num1, num2, op);
                    expression = before + result + after;
                    if (String.IsNullOrEmpty(before)&& String.IsNullOrEmpty(after)) {
                        return result;
                    }
                }
            }
#endif
            foreach (char currentOp in "EMA")
            {
                string operationRegexPart = "";
                switch (currentOp) {
                    case 'E': // Exponents
                        operationRegexPart = "(\\^)";
                        break;
                    case 'M': // Multiplication, Division
                        operationRegexPart = "(\\*|\\/)";
                        break;
                    case 'A': // Addition, Subtraction
                        operationRegexPart = "(\\+|\\-)";
                        break;
                }
                var currentRegEx = new Regex(string.Format(SimpleOperation, operationRegexPart, "{1}"));
                while (currentRegEx.IsMatch(expression))
                {
                    Match match = currentRegEx.Match(expression);
                    string num1 = match.Groups[1].Value;
                    string op = match.Groups[2].Value;
                    string num2 = match.Groups[3].Value;

                    string before, after, result;
                    before = expression.Substring(0, match.Index);
                    after = expression.Substring(match.Index + match.Length);
                    result = PerformOperation(num1, num2, op);
                    expression = before + result + after;
                    if (String.IsNullOrEmpty(before) && String.IsNullOrEmpty(after))
                    {
                        return result;
                    }
                }
            }
            return expression;
        }

        private static string PerformOperation(string firstNumberString, string secondNumberString, string operation)
        {
            double firstNumber = double.Parse(firstNumberString.Replace('_', '-'));
            double secondNumber = double.Parse(secondNumberString.Replace('_', '-'));
            double result;
            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (firstNumber == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero");
                    }
                    result = firstNumber / secondNumber;
                    break;
                case "^":
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
                case "sin":
                    result = Sin(firstNumber);
                    break;
                case "cos":
                    result = Cos(firstNumber);
                    break;
                default:
                    throw new ArgumentException("Invalid operation");
            }
            return result.ToString().Replace('-', '_');
        }
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
            number = number % (2 * Math.PI);
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