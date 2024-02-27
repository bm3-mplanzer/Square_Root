namespace MathematicalFunctionsTest
{
    public class Sqrt_BisectionTest
    {
        [Fact]
        public void Calculator_Sqrt_Bisection_NegativeFails()
        {
            var failed = false;
            try
            {
                Calculator.Sqrt_Bisection(-1);
            }
            catch
            {
                failed = true;
            }
            Assert.True(failed);
        }
        [Fact]
        public void Calculator_Sqrt_Bisection_2()
        {
            var sqrt = Calculator.Sqrt_Bisection(2);
            Assert.Equal(1.414213562373095, sqrt);
        }
        [Fact]
        public void Calculator_Sqrt_Bisection_Decimal()
        {
            var sqrt = Calculator.Sqrt_Bisection(.5);
            Assert.Equal(0.7071067811865476, sqrt);
        }
        [Fact]
        public void Calculator_Sqrt_Bisection_400()
        {
            var value = Calculator.Sqrt_Bisection(400);
            Assert.Equal(20, value);
        }
        [Fact]
        public void Calculator_Sqrt_NegativeFails()
        {
            var failed = false;
            try
            {
                Calculator.Sqrt(-1);
            }
            catch
            {
                failed = true;
            }
            Assert.True(failed);
        }
        [Fact]
        public void Calculator_Sqrt_2()
        {
            var sqrt = Calculator.Sqrt(2);
            Assert.Equal(1.414213562373095, sqrt);
        }
        [Fact]
        public void Calculator_Sqrt_Decimal()
        {
            var sqrt = Calculator.Sqrt(.5);
            Assert.Equal(.70710678118654746, sqrt);
        }
        [Fact]
        public void Calculator_Sqrt_400()
        {
            var value = Calculator.Sqrt_Bisection(400);
            Assert.Equal(20, value);
        }
    }
}