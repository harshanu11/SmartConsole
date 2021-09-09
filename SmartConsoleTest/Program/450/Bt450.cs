using System;
using Xunit;

namespace SmartConsoleTest.Program._450
{
    public class Bt450 
    {
        #region level order traversal
        public class BTNode1
        {
            public int data;
            public BTNode1 left, right;
            public BTNode1(int item)
            {
                data = item;
                left = right = null;
            }
        }
        public BTNode1 btRoot;
        void printLevelOrder()
        {
            int h = height1(btRoot);
            int i;
            for (i = 1; i <= h; i++)
            {
                printCurrentLevel(btRoot, i);
            }
        }

        public int height1(BTNode1 root)
        {
            if (btRoot == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
                int lheight = height1(root.left);
                int rheight = height1(root.right);

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

        public virtual void printCurrentLevel(BTNode1 root, int level)
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

        [Fact]
        public void LevelOrderTest()
        {
            this.btRoot = new BTNode1(1);
            this.btRoot.left = new BTNode1(2);
            this.btRoot.right = new BTNode1(3);
            this.btRoot.left.left = new BTNode1(4);
            this.btRoot.left.right = new BTNode1(5);
            Console.WriteLine("Level order traversal " +
                                "of binary tree is ");
            this.printLevelOrder();
        }
        #endregion
        #region Reverse Level Order traversal
        public class BinaryTree
        {
            public BTNode1 root;


            void reverseLevelOrder(BTNode1 node)
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


            void printGivenLevel(BTNode1 node, int level)
            {
                if (node == null)
                    return;
                if (level == 1)
                    Console.Write(node.data + " ");
                else if (level > 1)
                {
                    printGivenLevel(node.left, level - 1);
                    printGivenLevel(node.right, level - 1);
                }
            }

            /* Compute the "height" of a tree --
            the number of nodes along the longest
            path from the root node down to the
            farthest leaf node.*/
            int height(BTNode1 node)
            {
                if (node == null)
                    return 0;
                else
                {
                    /* compute the height of each subtree */
                    int lheight = height(node.left);
                    int rheight = height(node.right);

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
                tree.root = new BTNode1(1);
                tree.root.left = new BTNode1(2);
                tree.root.right = new BTNode1(3);
                tree.root.left.left = new BTNode1(4);
                tree.root.left.right = new BTNode1(5);

                Console.WriteLine("Level Order traversal " +
                                    "of binary tree is : ");
                tree.reverseLevelOrder(tree.root);
            }
        }
        #endregion
        #region Height of a tree

        int maxDepth(BTNode1 node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.left);
                int rDepth = maxDepth(node.right);

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

            tree.root = new BTNode1(1);
            tree.root.left = new BTNode1(2);
            tree.root.right = new BTNode1(3);
            tree.root.left.left = new BTNode1(4);
            tree.root.left.right = new BTNode1(5);

            Console.WriteLine("Height of tree is : " +
                                        maxDepth(tree.root));
        }
        #endregion
        #region Diameter of a tree
        class Solution
        {
            // Function to find the diameter of a Binary Tree.
            int diameterUtil(BTNode1 n, ref int dia)
            {
                // if node becomes null, we return 0.
                if (n == null) return 0;

                // calling the function recursively for the left and
                // right subtrees to find their heights.
                int l = diameterUtil(n.left, ref dia);
                int r = diameterUtil(n.right, ref dia);

                // storing the maximum possible value of l+r+1 in diameter.
                if (l + r + 1 > dia) dia = l + r + 1;

                // returning height of subtree.
                return 1 + Math.Max(l, r);
            }
            // Function to return the diameter of a Binary Tree.
            public int diameter(BTNode1 root)
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
        public static BTNode1 createNode(int val)
        {
            BTNode1 newNode = new BTNode1(0);
            newNode.data = val;
            newNode.left = null;
            newNode.right = null;
            return newNode;
        }

        public static void inorder(BTNode1 root)
        {
            if (root == null)
            {
                return;
            }
            inorder(root.left);
            Console.Write("{0:D} ", root.data);
            inorder(root.right);
        }

        public static BTNode1 mirrorify(BTNode1 root)
        {
            if (root == null)
            {
                return null;

            }
            BTNode1 mirror = createNode(root.data);
            mirror.right = mirrorify(root.left);
            mirror.left = mirrorify(root.right);
            return mirror;
        }

       [Fact]
        public void inorderTest()
        {

            BTNode1 tree = createNode(5);
            tree.left = createNode(3);
            tree.right = createNode(6);
            tree.left.left = createNode(2);
            tree.left.right = createNode(4);

            // Print inorder traversal of the input tree
            Console.Write("Inorder of original tree: ");
            inorder(tree);
            BTNode1 mirror = null;
            mirror = mirrorify(tree);

            // Print inorder traversal of the mirror tree
            Console.Write("\nInorder of mirror tree: ");
            inorder(mirror);
        }
        #endregion
    }
}
