using System;
using Xunit;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SmartConsoleTest
{
    public class GettingStarted
    {
        [Fact]
        public void charIsLetterTest()
        {

            #region Creating ds
            #region Array 2d jagged sixe 3
            Array a = Array.CreateInstance(typeof(char), 25);
            char[] c0 = new char[3] { 'x', 'y' ,'z'};
            char[] c1 = { 'a', 'b','c' };
            int[,] tda = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[][] ja = { new int[] { 1, 2, 3 } };
            #endregion
            string str = "hell you";
            #region HashSet_LinkedList_Stack_Queue
            HashSet<int> hs = new HashSet<int>();
            string[] words =
               { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> ll = new LinkedList<string>(words);
            Stack<int> stk = new Stack<int>();
            Queue<int> q = new Queue<int>();
            #endregion

            #region Tree_Graph

            #endregion
            #endregion

            #region CRUD_DS
            c1.SetValue('h', 1);
            c1.GetValue(0);
            tda.GetValue(0, 1);
            hs.Add(3);
            hs.Contains(3);
            hs.Remove(3);
            #region LinkList
            ll.AddFirst("today");//ll.RemoveFirst() ll.AddLast(mark1); ll.RemoveLast(); ll.AddAfter(current, "old"); .AddBefore(current, mark1); .Remove(mark1);ll.Clear();
            LinkedListNode<string> mark1 = ll.First;
            LinkedListNode<string> markPrev = ll.Last.Previous;
            var current = ll.Find("fox");// return fox as string
            if (ll.Contains("jumps"))
            {
                ll.RemoveFirst();
                ll.AddLast("yesterday");

            }
            ll.AddBefore(current, "quick");
            current = ll.Find("dog");
            ICollection<string> icoll = ll;
            string[] sArray = new string[ll.Count];
            ll.CopyTo(sArray, 0);
            #endregion
            stk.Push(4);
            stk.Pop();
            q.Enqueue(3);
            q.Dequeue();
            #endregion

            #region Traverse

            #endregion

            #region SortReverseCopy
            Array.Sort(c1); Array.Sort(c1, 1, 2);
            Array.Reverse(c1);
            Array.Copy(c1, 0, c1, 0, 3);
            ll.CopyTo(new string[100], 0);
            #endregion

            #region Resize
            Array.Resize(ref c1, 10);
            int[] Aint = Array.ConvertAll(c1, c => (int)Char.GetNumericValue(c));
            string st = new string(c1);
            st = string.Join("", c1);
            #endregion

            #region Find
            var result = Array.Find(c1, x => x == 'x');
            String ans = str.Substring(4, str.Length - 4) + str.Substring(0, 4);
            #endregion

            #region Recurrsion_BaclTracking

            #endregion

            #region DynamicProgramming

            #endregion

            #region Divide N concore

            #endregion

            #region Regex
            Regex rx = new Regex("[a-z]");
            Assert.True(rx.IsMatch("a"));
            #endregion
        }
    }
    #region Helper
    public class LinkedListNode
    {
        public int data
        {
            get;
            set;
        }

        public LinkedListNode next;
        public LinkedListNode(int data)
        {
            this.data = data;
        }
    }

    public class TreetNode
    {
        public int data
        {
            get;
            set;
        }

        public TreetNode left;
        public TreetNode right;

    }

    public class GraphOps
    {
    }
    #endregion
}
