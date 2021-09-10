using System.Diagnostics;
using CollectionTest;
using System;
using Xunit;

namespace DSA450
{
    public class BST450
    {
        public class BinarySearchTree
        {
            public BSTSNode1 root;
        }
        #region Fina a value in a BST

        public class BSTSNode1
        {
            public int key;
            public BSTSNode1 left, right;

            public BSTSNode1(int item)
            {
                key = item;
                left = right = null;
            }
        }

        // Root of BST
        BSTSNode1 rootbst;


        // This method mainly calls insertRec()
        void insert(int key)
        {
            rootbst = insertRec(rootbst, key);
        }

        BSTSNode1 insertRec(BSTSNode1 root, int key)
        {

            // If the tree is empty,
            // return a new node
            if (root == null)
            {
                root = new BSTSNode1(key);
                return root;
            }

            // Otherwise, recur down the tree
            if (key < root.key)
                root.left = insertRec(root.left, key);
            else if (key > root.key)
                root.right = insertRec(root.right, key);

            // Return the (unchanged) node pointer
            return root;
        }

        // This method mainly calls InorderRec()
        void inorder()
        {
            inorderRec(rootbst);
        }
        void inorderRec(BSTSNode1 root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Debug.WriteLine(root.key);
                inorderRec(root.right);
            }
        }
        [Fact]
        public void FindValInBstTest()
        {
            /* Let us create following BST
                50
            /	 \
            30	 70
            / \ / \
        20 40 60 80 */
            insert(50);
            insert(30);
            insert(20);
            insert(40);
            insert(70);
            insert(60);
            insert(80);

            // Print inorder traversal of the BST
            inorder();
        }
        #endregion
        #region Deletion of a node in a BST
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (root.Data > key)
                root.Left = DeleteNode(root.Left, key);
            else if (root.Data < key)
                root.Right = DeleteNode(root.Right, key);
            else
            {
                // case 1
                if (root.Left == null && root.Right == null)
                    return null;
                // case 2
                else if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                else
                {
                    // case 3
                    var minElement = GetMinElement(root.Right);
                    root.Data = minElement.Data;
                    root.Right = DeleteNode(root.Right, root.Data);
                }
            }

            return root;
        }

        private TreeNode GetMinElement(TreeNode root)
        {
            var current = root;

            while (current.Left != null)
                current = current.Left;

            return current;
        }
        #endregion
        #region Find min and max value in a BST
        public static BSTNode head;
        public virtual BSTNode insert(BSTNode node, int data)
        {
            if (node == null)
            {
                return (new BSTNode(data));
            }
            else
            {
                if (data <= node.Data)
                {
                    node.Left = insert(node.Left, data);
                }
                else
                {
                    node.Right = insert(node.Right, data);
                }
                return node;
            }
        }
        public virtual int minvalue(BSTNode node)
        {
            BSTNode current = node;

            /* loop down to find the leftmost leaf */
            while (current.Left != null)
            {
                current = current.Left;
            }
            return (current.Data);
        }
        [Fact]
        public void FindMinMaxTest()
        {
            BSTNode root = null;
            root = insert(root, 4);
            insert(root, 2);
            insert(root, 1);
            insert(root, 3);
            insert(root, 6);
            insert(root, 5);

            Debug.WriteLine("Minimum value of BST is " + minvalue(root));
        }
        #endregion
        #region Find inorder successor and inorder predecessor in a BST
        static BSTNode pre = new BSTNode(), suc = new BSTNode();

        static void findPreSuc(BSTNode root, int key)
        {

            // Base case
            if (root == null)
                return;

            // If key is present at root
            if (root.Data == key)
            {

                // The maximum value in left
                // subtree is predecessor
                if (root.Left != null)
                {
                    BSTNode tmp = root.Left;
                    while (tmp.Right != null)
                        tmp = tmp.Right;

                    pre = tmp;
                }

                // The minimum value in
                if (root.Right != null)
                {
                    BSTNode tmp = root.Right;

                    while (tmp.Left != null)
                        tmp = tmp.Left;

                    suc = tmp;
                }
                return;
            }

            if (root.Data > key)
            {
                suc = root;
                findPreSuc(root.Left, key);
            }

            // Go to right subtree
            else
            {
                pre = root;
                findPreSuc(root.Right, key);
            }
        }

        static BSTNode insert1(BSTNode node, int key)
        {
            if (node == null)
                return new BSTNode(key);
            if (key < node.Data)
                node.Left = insert1(node.Left, key);
            else
                node.Right = insert1(node.Right, key);

            return node;
        }

        [Fact]
        public void InorderSuccessor()
        {

            // Key to be searched in BST
            int key = 65;

            /*
            * Let us create following BST
            *		 50
            *		 / \
            *	 30 70
            *	 / \ / \
            *	 20 40 60 80
            */

            BSTNode root = new BSTNode();
            root = insert(root, 50);
            insert(root, 30);
            insert(root, 20);
            insert(root, 40);
            insert(root, 70);
            insert(root, 60);
            insert(root, 80);

            findPreSuc(root, key);
            if (pre != null)
                Debug.WriteLine("Predecessor is " + pre.Data);
            else
                Debug.WriteLine("No Predecessor");

            if (suc != null)
                Debug.WriteLine("Successor is " + suc.Data);
            else
                Debug.WriteLine("No Successor");
        }
        #endregion
        #region Check if a tree is a BST or not 

        public virtual bool BST
        {
            get
            {
                return isBSTUtil(rootbst, int.MinValue, int.MaxValue);
            }
        }

        public virtual bool isBSTUtil(BSTSNode1 node, int min, int max)
        {
            /* an empty tree is BST */
            if (node == null)
            {
                return true;
            }

            /* false if this node violates the min/max constraints */
            if (node.key < min || node.key > max)
            {
                return false;
            }

            return (isBSTUtil(node.left, min, node.key - 1) && isBSTUtil(node.right, node.key + 1, max));
        }

        [Fact]
        public void IsBstTest()
        {
            BinarySearchTree tree = new BinarySearchTree();
            tree.root = new BSTSNode1(4);
            tree.root.left = new BSTSNode1(2);
            tree.root.right = new BSTSNode1(5);
            tree.root.left.left = new BSTSNode1(1);
            tree.root.left.right = new BSTSNode1(3);

            if (isBSTUtil(tree.root, int.MinValue, int.MaxValue))
            {
                Debug.WriteLine("IS BST");
            }
            else
            {
                Debug.WriteLine("Not a BST");
            }
        }
        #endregion
    }
}
