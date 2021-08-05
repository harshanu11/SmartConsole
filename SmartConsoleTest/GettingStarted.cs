using System;
using Xunit;
using System.Collections.Generic;

namespace SmartConsoleTest
{
    public class GettingStarted
    {
        [Fact]
        public void charIsLetterTest()
        {
            // creating
            char[] c = new char[26];
            Array c1 = Array.CreateInstance(typeof(char), 26);
            char[] c2 = new char[] { 'a', 'b', 'c' };
            char[] c3 = { 'x', 't', 'x' };
            int[,] c4 = {
                            {1,2,3},
                            {4,5,6},
                            {6,7,8}
                        };
            int[,] c5 = new int[3, 5];
            int[][] c6 = new int[3][];
            HashSet<int> hs = new HashSet<int>();
            string[] words =
               { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            //Console.WriteLine(c4[0,2]);	Console.WriteLine(c4.Length);Console.WriteLine(c5.GetLength(1));		Console.WriteLine(c5.GetLength(0));


            // get set array value 
            c3.SetValue('h', 2);
            c4.GetValue(0, 1);
            hs.Add(3);
            hs.Add(3);
            hs.Contains(3);
            hs.Remove(3);
            sentence.AddFirst("today");
            LinkedListNode<string> mark1 = sentence.First;
            LinkedListNode<string> markPrev = sentence.Last.Previous;
            var current = sentence.Find("fox");
            if (sentence.Contains("jumps"))
            {
                sentence.RemoveFirst();
                sentence.AddLast("yesterday");

            }
            sentence.AddBefore(current, "quick");
            current = sentence.Find("dog");
            ICollection<string> icoll = sentence;
            //Console.WriteLine(c3[2]);

            // sort reverse 
            Array.Sort(c3); Array.Sort(c3, 1, 2);
            Array.Reverse(c3);
            // copy
            Array.Copy(c3, 0, c1, 0, 3);

            // resize
            Array.Resize(ref c3, 10);
            int[] Aint = Array.ConvertAll(c3, c => (int)Char.GetNumericValue(c));
            string st = new string(c3);
            st = string.Join("", c3);
            // find 
            var result = Array.Find(c3, x => x == 'x');
            sentence.CopyTo(new string[100], 0);
        }
    }
}
