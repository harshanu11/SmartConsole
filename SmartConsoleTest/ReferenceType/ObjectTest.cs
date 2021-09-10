using System.Diagnostics;
using System;
using Xunit;

namespace ReferenceTypeTest
{
    public class ObjectTest
    {
        [Fact]
        public void CheckVariableAndObject()
        {
            MyObjectClass o = new MyObjectClass();
            MyObjectClass o1 = new MyObjectClass();
            MyObjectClass o2 = o;

            Assert.NotEqual(o1,o);
            Assert.True(o2.Equals(o));
            Assert.True(ReferenceEquals(o, o2));
            Assert.True(o2 == o);
        }
		[Fact]
		public void TestDeepCopy()
		{
			CopyClass o1 = new CopyClass();
			o1.cl2 = new CopyClassTest();
			CopyClass o2 = o1.DeepCopy();
			o2.cl2 = new CopyClassTest();


			o1.cl2 = new CopyClassTest();
			o1.num = 1;
			o2.num = 2;
			o1.cl2.num2 = 11;
			o2.cl2.num2 = 22;
			Debug.WriteLine(o1.num);
			Debug.WriteLine(o2.num);
			Debug.WriteLine(o1.cl2.num2);
			Debug.WriteLine(o2.cl2.num2);
			Debug.WriteLine("Hello");
		}
    }
    public class MyObjectClass
    {
        public int Intprop = 0;
        public string MyProperty = "55";
    }
	public class CopyClass
	{
		public int num
		{
			get;
			set;
		}

		public CopyClassTest cl2
		{
			get;
			set;
		}

		public CopyClass DeepCopy()
		{
			CopyClass cl = new CopyClass();
			cl = (CopyClass)this.MemberwiseClone();
			cl.cl2 = new CopyClassTest();
			cl.num = 0;
			return cl;
		}
	}

	public class CopyClassTest
	{
		public int num2
		{
			get;
			set;
		}
	}
}
