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

        [Fact]
        public void SortedArrayToBalanceTreeTest()
        {
            TreeNodev1 root;
            BinaryTreev1 tree = new BinaryTreev1();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);
            Console.WriteLine("Preorder traversal of constructed BST");
            tree.preOrder(root);
        }

    }

    public class TreeNodev1
    {

        public int data;
        public TreeNodev1 left, right;

        public TreeNodev1(int d)
        {
            data = d;
            left = right = null;
        }
    }
    public class BinaryTreev1
    {

        public static TreeNodev1 root;

        /* A function that constructs Balanced Binary Search Tree
		from a sorted array */
        public virtual TreeNodev1 sortedArrayToBST(int[] arr, int start, int end)
        {

            /* Base Case */
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            TreeNodev1 node = new TreeNodev1(arr[mid]);

            /* Recursively construct the left subtree and make it
			left child of root */
            node.left = sortedArrayToBST(arr, start, mid - 1);

            /* Recursively construct the right subtree and make it
			right child of root */
            node.right = sortedArrayToBST(arr, mid + 1, end);

            return node;
        }

        /* A utility function to print preorder traversal of BST */
        public virtual void preOrder(TreeNodev1 node)
        {
            if (node == null)
            {
                return;
            }
            Console.Write(node.data + " ");
            preOrder(node.left);
            preOrder(node.right);
        }

    }
}
