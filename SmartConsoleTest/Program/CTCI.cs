using System;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class CTCI 
    {
        #region ArrayStr
        public void CheckDuplicateStr()
        {
            int[] c = new int[128];

            string str = "afhsdfsahhlsadf";
            for (int i = 0; i < str.Length; i++)
            {
                c[str[i]]++;
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] > 0)
                {
                    Console.WriteLine((char)i);
                }
            }
        }
        public void CheckPermutationstr()
        {
            int[] c = new int[128];
            int[] c1 = new int[128];
            string str = "afhsdfsahhlsadf";
            string str1 = "afhsdfsahhlsadf";
            for (int i = 0; i < str.Length; i++)
            {
                c[str[i]]++;
                c1[str1[i]]++;
            }
            bool ans = true;
            for (int i = 0; i < c.Length; i++)
            {
                if (str.Length == str1.Length && c[i] != c1[i])
                {
                    ans = false;
                    break;
                }
            }

            Console.WriteLine(ans);
        }
        [Fact]
        public void FindReplaceTesr()
        {
            int[] c = new int[128];

            string str = "Mr 3ohn Smith";
            char[] ch = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    count++;
                }
            }
            char[] ch1 = new char[ch.Length + (3 * 2)];
            Console.WriteLine(ch.Length + (3 * 2));
            bool ans = true;
            int count1 = 0;
            for (int i = 0; i < ch1.Length; i++)
            {
                if (ch[count1] == ' ')
                {
                    //count++;
                    ch1[i] = '%';
                    ch1[i + 1] = '2';
                    ch1[i + 2] = '0';
                    i = i + 2;
                }
                else
                {
                    ch1[i] = ch[count1];
                }

                    count1++;
            }

            Console.WriteLine(new String(ch1));
        }
        #endregion

    }
}
