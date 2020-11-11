using System;
using System.Threading;
using Xunit;

namespace SmartConsoleTest
{
    public class ReferenceType
    {
        ReferenceTypeVarible r = new ReferenceTypeVarible();
        ValueTypeObj v = new ValueTypeObj();
        [Fact]
        public void TestValRefType() 
        {
            ReferenceTypeVarible r1 = new ReferenceTypeVarible(); ;

            Type tv = v.GetType();
            Type tr = r.GetType();
            Type tr1 = r1.GetType();

            DateTime dt = DateTime.Now;

            v.Number = 0;
            v.str += "s";
            v.obj = dt;

            r.Number = 0;
            r.str += "s";
            r.obj = dt;



            Processor.Change(v);
            Processor.Change(r);

            Assert.Equal(0, v.Number);
            Assert.Equal("s", v.str);
            Assert.Equal(dt, v.obj);

            Assert.NotEqual(0, r.Number);
            Assert.NotEqual("s",r.str);
            Assert.NotEqual(dt, r.obj);

            Assert.NotEqual(tr.GetHashCode(), tr1.GetHashCode());
        }
    }
    public class ReferenceTypeVarible
    {
        public int Number;
        public string str;
        public object obj;
    }
    public struct ValueTypeObj
    {
        public int Number;
        public string str;
        public object obj;
    }
    public class Processor
    {
        public static void Change(ReferenceTypeVarible r)
        {
            r.Number = 1;
            r.str +="s";
            r.obj = DateTime.Now;
        }
        public static void Change(ValueTypeObj v)
        {
            v.Number = 1;
            v.str += "s";
            v.obj = DateTime.Now;
        }
    }
}
