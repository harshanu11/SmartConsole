using System;

namespace CollectionTest
{
    public class TreeNode
    {
        public int Data;
        public TreeNode Left;
        public TreeNode Right;
        public void DisplayNode()
        {
            Console.Write(Data + " ");
        }
        public TreeNode()
        {

        }
        public TreeNode(int data)
        {
            TreeNode newNode = new TreeNode();
            newNode.Data = data;
        }
    }
}
