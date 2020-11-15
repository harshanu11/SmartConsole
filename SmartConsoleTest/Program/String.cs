using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class String
    {
		[Fact]
		public void Palandrom()
		{ 

			Assert.Equal(1,CheckPalandrom("abas7saba"));
			Assert.Equal(0, CheckPalandrom("abas7seaba"));
		}

		private int CheckPalandrom(string palan)
        {

			int myChecker = 0;
			int myOp = 0;
			for (int i = 0; i < palan.Length / 2; i++)
			{
				if (palan[i] == palan[palan.Length - 1 - i])
				{
					myChecker += 1;
				}
			}

			if (myChecker == palan.Length / 2)
				return 1;
			else
				return  0;
			
		}
    }
}
