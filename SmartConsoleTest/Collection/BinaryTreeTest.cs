using System;
using System.Diagnostics;
using Xunit;

namespace CollectionTest
{
    public class BinaryTreeTest
    {
        BinaryTreeOps bstObj = new BinaryTreeOps();

        [Fact]
        public void InsertInBinaryTree()
        {
            TreeNode root = new TreeNode(0);
            bstObj.Insert(root,50);
            bstObj.Insert(root,17);
            bstObj.Insert(root,23);
            bstObj.Insert(root,12);
            bstObj.Insert(root,19);
            bstObj.Insert(root,54);
            bstObj.Insert(root,9);
            bstObj.Insert(root,14);
            bstObj.Insert(root,67);
            bstObj.Insert(root,76);
            bstObj.Insert(root,72);
        }

        [Fact]
        public void DeleteInBinaryTree()
        {
            TreeNode root = new TreeNode(0);
            bstObj.Insert(root, -50);
            bstObj.Insert(root, -17);
            bstObj.Insert(root, -23);
            bstObj.Insert(root, 12);
            bstObj.Insert(root, 19);
            bstObj.Insert(root, 54);
            bstObj.Insert(root, 9);
            bstObj.Insert(root, 14);
            bstObj.Insert(root, 67);
            bstObj.Insert(root, 76);
            bstObj.Insert(root, 72);
            bstObj.deleteRec(root,0);// delete root 
            bstObj.deleteRec(root,14);// delete vertisis 
        }
        [Fact]
        public void TraverseDepthFirstTree() {
            TreeNode root;
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = bstObj.sortedArrayToBST(arr, 0, n - 1);

            bstObj.printPostorder(root);
            bstObj.printInorder(root);
            bstObj.printPreorder(root);
        }
        [Fact]
        public void TraverseBreathFirstTree()
        {
            TreeNode root;
            BinaryTreeOps tree = new BinaryTreeOps();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);

            bstObj.rootBreathFirst = new TreeNode(1);
            bstObj.rootBreathFirst.Left = new TreeNode(2);
            bstObj.rootBreathFirst.Right = new TreeNode(3);
            bstObj.rootBreathFirst.Left.Left = new TreeNode(4);
            bstObj.rootBreathFirst.Left.Right = new TreeNode(5);

            bstObj.printLevelOrder(root);
        }
        [Fact]
        public void SortedArrayToBalanceTreeTest()
        {
            TreeNode root;
            BinaryTreeOps tree = new BinaryTreeOps();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            root = tree.sortedArrayToBST(arr, 0, n - 1);
            Debug.WriteLine("Preorder traversal of constructed BST");
            tree.preOrder(root);
        }
    }
}
