using System;
using Xunit;

namespace CollectionTest
{
    public class TreeTest
    {
        public TreeNode rootBreathFirst;
        [Fact]
        public void InsertInBinaryTree()
        {
            BinaryTreeOps nums = new BinaryTreeOps();
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
        [Fact]
        public void TraverseDepthFirstTree() {
            TreeNode root;
            BinaryTreeOps tree = new BinaryTreeOps();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);

            printPostorder(root);
            printInorder(root);
            printPreorder(root);
        }
        [Fact]
        public void TraverseBreathFirstTree()
        {
            TreeNode root;
            BinaryTreeOps tree = new BinaryTreeOps();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);

            printPostorder(root);
            printInorder(root);
            printPreorder(root);


            rootBreathFirst = new TreeNode(1);
            rootBreathFirst.Left = new TreeNode(2);
            rootBreathFirst.Right = new TreeNode(3);
            rootBreathFirst.Left.Left = new TreeNode(4);
            rootBreathFirst.Left.Right = new TreeNode(5);

            printLevelOrder();
        }
        [Fact]
        public void SortedArrayToBalanceTreeTest()
        {
            TreeNode root;
            BinaryTreeOps tree = new BinaryTreeOps();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);
            Console.WriteLine("Preorder traversal of constructed BST");
            tree.preOrder(root);
        }


        void printPostorder(TreeNode node)
        {
            if (node == null)
                return;

            printPostorder(node.Left);
            printPostorder(node.Right);
        }
        void printInorder(TreeNode node)
        {
            if (node == null)
                return;

            printInorder(node.Left);
            printInorder(node.Right);
        }

        void printPreorder(TreeNode node)
        {
            if (node == null)
                return;

            printPreorder(node.Left);
            printPreorder(node.Right);
        }
        public virtual int height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.Left);
                int rheight = height(root.Right);

                /* use the larger one */
                if (lheight > rheight)
                {
                    return (lheight + 1);
                }
                else
                {
                    return (rheight + 1);
                }
            }
        }
        public virtual void printLevelOrder()
        {
            int h = height(rootBreathFirst);
            int i;
            for (i = 1; i <= h; i++)
            {
                printCurrentLevel(rootBreathFirst, i);
            }
        }
        public virtual void printCurrentLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.Data + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.Left, level - 1);
                printCurrentLevel(root.Right, level - 1);
            }
        }
    }
}
