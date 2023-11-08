using MathematicalFunctions;

namespace MathematicalFunctionsTest
{
    public class GenerationUnitTests
    {
        [Fact]
        public void Implementation_Sqrt_25()
        {
            var sqrt = Implementation.Sqrt(25);
            Assert.Equal(5, sqrt);
        }
        [Fact]
        public void Implementation_Sqrt_225()
        {
            var sqrt = Implementation.Sqrt(225);
            Assert.Equal(15, sqrt);
        }
        [Fact]
        public void Implementation_Sqrt_400()
        {
            var sqrt = Implementation.Sqrt(400);
            Assert.Equal(20, sqrt);
        }
        [Fact]
        public void Implementation_Sin_2PI()
        {
            var sin = Implementation.Sin(2 * Math.PI);
            Assert.Equal(0, sin);
        }
        [Fact]
        public void Implementation_Cos_PI()
        {
            var cos = Implementation.Cos(Math.PI);
            Assert.Equal(-1, cos);
        }
    }
}