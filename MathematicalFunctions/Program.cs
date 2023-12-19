using MathematicalFunctions;
//Console.WriteLine("square root of 25: {0}", Implementation.Sqrt(25));
//Console.WriteLine("square root of 400: {0}", Calculator.Sqrt(25));
var x0 = "1 - (4-1) - 1"; //3 + 4 * 2 / (1 - 5)^2 + sin(0.5) + cos(0.8)
Console.WriteLine("{0} = {1}", x0, Calculator.EvaluateExpression(x0));

while (true)
{
    Console.WriteLine("Enter an expression or 'exit' to quit:");
    string input = Console.ReadLine() ?? "";

    if (input == "" || input == "exit")
        break;

    try
    {
        string result = Calculator.EvaluateExpression(input);
        Console.WriteLine("Result: " + result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
//Console.WriteLine("sine of Pi/6: Should be 0.5, is {0}", Implementation.Sin(Math.PI/6));
//Console.WriteLine("sine of 0.5, should be 0.479425538604203 {0}", Math.Sin(0.5));
//Console.WriteLine("sine of 1, should be  {0}", Implementation.Sin(2));