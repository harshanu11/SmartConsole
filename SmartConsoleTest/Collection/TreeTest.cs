using System;
using Xunit;

namespace CollectionTest
{
    public class TreeTest
    {
        [Fact]
        public void InsertInBinaryTree()
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(50);
            nums.Insert(17);
            nums.Insert(23);
            nums.Insert(12);
            nums.Insert(19);
            nums.Insert(54);
            nums.Insert(9);
            nums.Insert(14);
            nums.Insert(67);
            nums.Insert(76);
            nums.Insert(72);
        }
    }
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
    public class BinarySearchTree
    {
        public TreeNode root;
        public BinarySearchTree()
        {
            root = null;
        }
        public void Insert(int input)
        {
            TreeNode newNode = new TreeNode();
            newNode.Data = input;
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;
                while (true)
                {
                    parent = current;
                    if (input < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
        public static TreeNode insert(TreeNode root, int data)
        {
            if (root == null)
            {
                return new TreeNode(data);
            }
            else
            {
                TreeNode cur;
                if (data <= root.Data)
                {
                    cur = insert(root.Left, data);
                    root.Left = cur;
                }
                else
                {
                    cur = insert(root.Right, data);
                    root.Right = cur;
                }
                return root;
            }
        }
    }
}
