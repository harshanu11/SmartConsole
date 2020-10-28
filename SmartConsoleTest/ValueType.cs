using Xunit;

namespace SmartConsoleTest
{
    public class ValueType
    {
        [Fact]
        public void ValueTypeTest() 
        {
            var p1 = new MutablePoint(1, 2);
            var p2 = p1;
            p2.Y = 200;
            Assert.Equal(1,p1.X);
            Assert.Equal(2,p1.Y);
            Assert.Equal(200,p2.Y);

            MutateAndDisplay(p2);
            Assert.Equal(1, p2.X);
            Assert.Equal(200, p2.Y);

        }
        public struct MutablePoint
        {
            public int X;
            public int Y;

            public MutablePoint(int x, int y) => (X, Y) = (x, y);

            public override string ToString() => $"({X}, {Y})";
        }

        private static void MutateAndDisplay(MutablePoint p)
        {
            p.X = 100;
        }
    }
}
