namespace MathematicalFunctionsTest
{
    public class SinCosTest
    {
        [Fact]
        public void Calculator_Sin_0()
        {
            var value = Calculator.Sin(0);
            Assert.Equal(0, value);
        }
        [Fact]
        public void Calculator_Sin_90()
        {
            var value = Calculator.Sin(.5);
            Assert.Equal(0.47942553860420301, value);
        }
        [Fact]
        public void Calculator_Sin_10Pi()
        {
            var value = Calculator.Sin(10*Math.PI);
            Assert.Equal(0, value);
        }
    }
}