using System.Diagnostics;
using System;
using Xunit;
using CollectionTest;
using System.Collections.Generic;

namespace DSA450
{
    public class Bt450 
    {
        #region level order traversal

        public TreeNode btRoot;
        void printLevelOrder()
        {
            int h = height1(btRoot);
            int i;
            for (i = 1; i <= h; i++)
            {
                printCurrentLevel(btRoot, i);
            }
        }

        public int height1(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int lheight = height1(root.Left);
                int rheight = height1(root.Right);
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
        void printTreeLevelOrder1(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode tempNode = queue.Dequeue();
                Debug.Write(tempNode.Data + " ");

                if (tempNode.Left != null)
                {
                    queue.Enqueue(tempNode.Left);
                }
                if (tempNode.Right != null)
                {
                    queue.Enqueue(tempNode.Right);
                }
            }
        }

        void printCurrentLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Debug.Write(root.Data + " ");
            }
            else if (level > 1)
            {
                printCurrentLevel(root.Left, level - 1);
                printCurrentLevel(root.Right, level - 1);
            }
        }

        [Fact]
        public void LevelOrderTest()
        {
            this.btRoot = new TreeNode(1);
            this.btRoot.Left = new TreeNode(2);
            this.btRoot.Right = new TreeNode(3);
            this.btRoot.Left.Left = new TreeNode(4);
            this.btRoot.Left.Right = new TreeNode(5);
            Debug.WriteLine("Level order traversal " +
                                "of binary tree is ");
            this.printLevelOrder();
            // second aproach 
            printTreeLevelOrder1(btRoot);
        }
        #endregion
        #region Reverse Level Order traversal
        public class BinaryTree
        {
            public TreeNode root;
            void reverseLevelOrder(TreeNode node)
            {
                int h = height(node);
                int i;
                for (i = h; i >= 1; i--)

                // THE ONLY LINE DIFFERENT
                // FROM NORMAL LEVEL ORDER
                {
                    printGivenLevel(node, i);
                }
            }
            void printGivenLevel(TreeNode node, int level)
            {
                if (node == null)
                    return;
                if (level == 1)
                    Debug.Write(node.Data + " ");
                else if (level > 1)
                {
                    printGivenLevel(node.Left, level - 1);
                    printGivenLevel(node.Right, level - 1);
                }
            }
            int height(TreeNode node)
            {
                if (node == null)
                    return 0;
                else
                {
                    /* compute the height of each subtree */
                    int lheight = height(node.Left);
                    int rheight = height(node.Right);

                    /* use the larger one */
                    if (lheight > rheight)
                        return (lheight + 1);
                    else
                        return (rheight + 1);
                }
            }

            [Fact]
            public void ReverseTraversalTest()
            {
                BinaryTree tree = new BinaryTree();

                // Let us create trees shown
                // in above diagram
                tree.root = new TreeNode(1);
                tree.root.Left = new TreeNode(2);
                tree.root.Right = new TreeNode(3);
                tree.root.Left.Left = new TreeNode(4);
                tree.root.Left.Right = new TreeNode(5);

                Debug.WriteLine("Level Order traversal " +
                                    "of binary tree is : ");
                tree.reverseLevelOrder(tree.root);
            }
        }
        #endregion
        #region Height of a tree

        int maxDepth(TreeNode node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.Left);
                int rDepth = maxDepth(node.Right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }

        [Fact]
        public void TreeHeight()
        {
            BinaryTree tree = new BinaryTree();

            tree.root = new TreeNode(1);
            tree.root.Left = new TreeNode(2);
            tree.root.Right = new TreeNode(3);
            tree.root.Left.Left = new TreeNode(4);
            tree.root.Left.Right = new TreeNode(5);

            Debug.WriteLine("Height of tree is : " +
                                        maxDepth(tree.root));
        }
        #endregion
        #region Diameter of a tree
        class Solution
        {
            // Function to find the diameter of a Binary Tree.
            int diameterUtil(TreeNode n, ref int dia)
            {
                // if node becomes null, we return 0.
                if (n == null) return 0;

                // calling the function recursively for the Left and
                // Right subtrees to find their heights.
                int l = diameterUtil(n.Left, ref dia);
                int r = diameterUtil(n.Right, ref dia);

                // storing the maximum possible value of l+r+1 in diameter.
                if (l + r + 1 > dia) dia = l + r + 1;

                // returning height of subtree.
                return 1 + Math.Max(l, r);
            }
            // Function to return the diameter of a Binary Tree.
            public int diameter(TreeNode root)
            {
                int dia = 0;
                // calling the function to find the result.
                diameterUtil(root, ref dia);
                // returning the result.
                return dia;
            }
        }
        #endregion
        #region Mirror of a tree
        public static TreeNode createNode(int val)
        {
            TreeNode newNode = new TreeNode(0);
            newNode.Data = val;
            newNode.Left = null;
            newNode.Right = null;
            return newNode;
        }

        public static void inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            inorder(root.Left);
            Debug.Write(root.Data);
            inorder(root.Right);
        }

        public static TreeNode mirrorify(TreeNode root)
        {
            if (root == null)
            {
                return null;

            }
            TreeNode mirror = createNode(root.Data);
            mirror.Right = mirrorify(root.Left);
            mirror.Left = mirrorify(root.Right);
            return mirror;
        }

       [Fact]
        public void inorderTest()
        {

            TreeNode tree = createNode(5);
            tree.Left = createNode(3);
            tree.Right = createNode(6);
            tree.Left.Left = createNode(2);
            tree.Left.Right = createNode(4);

            // Print inorder traversal of the input tree
            Debug.Write("Inorder of original tree: ");
            inorder(tree);
            TreeNode mirror = null;
            mirror = mirrorify(tree);

            // Print inorder traversal of the mirror tree
            Debug.Write("\nInorder of mirror tree: ");
            inorder(mirror);
        }
        #endregion
    }
}
