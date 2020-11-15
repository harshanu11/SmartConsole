using Xunit;

namespace SmartConsoleTest
{
    public class ObjectTest
    {
        [Fact]
        public void CheckVariableAndObject()
        {



            MyObjectClass o = new MyObjectClass();
            MyObjectClass o1 = new MyObjectClass();
            MyObjectClass o2 = o;

            Assert.True(o2.Equals(o));
            Assert.True(ReferenceEquals(o, o2));
            Assert.True(o2 == o);
        }
    }
    public class MyObjectClass
    {

        public int Intprop = 0;
        public string MyProperty = "55";
    }
}
