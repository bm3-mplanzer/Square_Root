namespace MathematicalFunctionsTest
{
    public class CalculatorTest
    {
        [Fact]
        public void Implementation_Calculate_MinusMultiplication()
        {
            var sqrt = Calculator.Calculate("1 - (4-1) * (0-1)");
            Assert.Equal(4, sqrt);
        }
        [Fact]
        public void Implementation_Calculate_Exponents()
        {
            var sqrt = Calculator.Calculate("(22^2)/2-1");
            Assert.Equal(241, sqrt);
        }
        [Fact]
        public void Implementation_Calculate_ComplexParenthesis()
        {
            var sqrt = Calculator.Calculate("(3-(2+4))/2*(44*(1/22))");
            Assert.Equal(-3, sqrt);
        }
        [Fact]
        public void Implementation_Calculate_Decimals()
        {
            var sqrt = Calculator.Calculate("0.1*0.2");
            Assert.Equal(0.02, sqrt);
        }
    }
}