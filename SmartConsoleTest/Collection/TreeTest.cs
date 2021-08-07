using System;
using Xunit;

namespace CollectionTest
{
    public class TreeTest
    {
        public TreeNodev1 rootBreathFirst;
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
        public void TraverseDepthFirstTree() {
            TreeNodev1 root;
            BinaryTreev1 tree = new BinaryTreev1();
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
            TreeNodev1 root;
            BinaryTreev1 tree = new BinaryTreev1();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);

            printPostorder(root);
            printInorder(root);
            printPreorder(root);


            rootBreathFirst = new TreeNodev1(1);
            rootBreathFirst.left = new TreeNodev1(2);
            rootBreathFirst.right = new TreeNodev1(3);
            rootBreathFirst.left.left = new TreeNodev1(4);
            rootBreathFirst.left.right = new TreeNodev1(5);

            printLevelOrder();
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


        void printPostorder(TreeNodev1 node)
        {
            if (node == null)
                return;

            printPostorder(node.left);
            printPostorder(node.right);
        }
        void printInorder(TreeNodev1 node)
        {
            if (node == null)
                return;

            printInorder(node.left);
            printInorder(node.right);
        }

        void printPreorder(TreeNodev1 node)
        {
            if (node == null)
                return;

            printPreorder(node.left);
            printPreorder(node.right);
        }
        public virtual int height(TreeNodev1 root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height(root.left);
                int rheight = height(root.right);

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
        public virtual void printCurrentLevel(TreeNodev1 root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.Write(root.data + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.left, level - 1);
                printCurrentLevel(root.right, level - 1);
            }
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
