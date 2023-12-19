namespace MathematicalFunctionsTest
{
    public class ExpressionTest
    {
        [Fact]
        public void Implementation_EvaluateExpression_MinusMultiplication()
        {
            var sqrt = Calculator.EvaluateExpression("1 - (4-1) * (0-1)");
            Assert.Equal("4", sqrt);
        }
        [Fact]
        public void Implementation_EvaluateExpression_Exponents()
        {
            var sqrt = Calculator.EvaluateExpression("(22^2)/2-1");
            Assert.Equal("241", sqrt);
        }
        [Fact]
        public void Implementation_EvaluateExpression_ComplexParenthesis()
        {
            var sqrt = Calculator.EvaluateExpression("(3-(2+4))/2*(44*(1/22))");
            Assert.Equal("_3", sqrt);
        }
    }
}