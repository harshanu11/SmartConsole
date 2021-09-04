using CollectionTest;
using System.Collections.Generic;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class DsAlgo450
    {
        #region Array
        [Fact]
        public void A_ReverseString()
        {
            var inStr = "12345".ToCharArray();
            var opStr = "54321";
            int start = 0;
            int end = inStr.Length - 1;
            while (start < end)
            {
                var temp = inStr[start];
                inStr[start] = inStr[end];
                inStr[end] = temp;
                start++;
                end--;
            }
            Assert.Equal(new string(inStr), opStr);
            // swap via recursion 
            // temp var

        }
        #endregion
        #region String

        #endregion
        #region Searching & Sorting
        [Fact]
        public void A_FindFirst_Last_occer_of_x()
        {
            // find 5 first and last occerence
            int[] inArr = { 1, 3, 5, 5, 5, 5, 67, 123, 125 };
        }
        #endregion
        #region LinkedList
        [Fact]
        public void A_Reverse_itrative_recursive_LLTest()
        {
            LLNode llReverse = new LLNode(1);
            llReverse.nextNode = new LLNode(2);
            llReverse.nextNode = new LLNode(3);
            llReverse.nextNode = new LLNode(4);
            LLNode head = llReverse;
            while (head != null)
            {
                //1-2-3-4-null
                //2-1-3-4-null
                //2-

            }
        }
        #endregion
        #region Binary Tree

        [Fact]
        public void A_LeverOrder_Traverse()
        {
            TreeNode tree = new TreeNode();
            tree.Data = 1;
            tree.Left = new TreeNode();
            tree.Left.Data = 2;
            tree.Right = new TreeNode();
            tree.Right.Data = 3;
            tree.Left.Left = new TreeNode();
            tree.Left.Left.Data = 4;
            tree.Right.Right = new TreeNode();
            tree.Right.Right.Data = 5;

            TreeNode head = tree;
            Stack<int> st = new Stack<int>();
            st.Push(head.Data);
            while (st.Count != 0)
            {

            }
        }
        #endregion
    }
}