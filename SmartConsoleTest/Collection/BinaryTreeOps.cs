using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CollectionTest
{
    public class BinaryTreeOps
    {
        List<int> response = new List<int>();
        public TreeNode rootBreathFirst;
        public TreeNode root;
        public BinaryTreeOps()
        {
            root = null;
        }

        public TreeNode Insert(TreeNode root, int data)
        {

            if (root == null)
            {
                return new TreeNode(data);
            }
            else
            {
                TreeNode current;
                if (data <= root.Data)
                {
                    current = Insert(root.Left, data);
                    root.Left = current;
                }
                else
                {
                    current = Insert(root.Right, data);
                    root.Right = current;
                }
                return root;
            }
        }
        public TreeNode deleteRec(TreeNode root, int Data)
        {
            if (root == null)
                return root;

            if (Data < root.Data)
                root.Left = deleteRec(root.Left, Data);
            else if (Data > root.Data)
                root.Right = deleteRec(root.Right, Data);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Data = minValue(root.Right);

                root.Right = deleteRec(root.Right, root.Data);
            }
            return root;
        }
        int minValue(TreeNode root)
        {
            int minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }
        public virtual TreeNode sortedArrayToBST(int[] arr, int start, int end)
        {

            /* Base Case */
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(arr[mid]);

            node.Left = sortedArrayToBST(arr, start, mid - 1);

            node.Right = sortedArrayToBST(arr, mid + 1, end);

            return node;
        }
        public virtual void preOrder(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            preOrder(node.Left);
            preOrder(node.Right);
        }

        public void printPostorder(TreeNode node)
        {
            if (node == null)
                return;

            printPostorder(node.Left);
            printPostorder(node.Right);
            Debug.WriteLine(node.Data);
        }
        public void printInorder(TreeNode node)
        {
            if (node == null)
                return;

            printInorder(node.Left);
            Debug.WriteLine(node.Data);
            printInorder(node.Right);
        }
        public TreeNode GetInOrder(TreeNode node)
        {
            if (node == null) return node;
            GetInOrder(node.Left);
            response.Add(node.Data);
            GetInOrder(node.Right);
            return node;
        }

        public void printPreorder(TreeNode node)
        {
            if (node == null)
                return;

            Debug.WriteLine(node.Data);
            printPreorder(node.Left);
            printPreorder(node.Right);
        }
        public virtual int height(TreeNode root)
        {
            if (root == null) return 0;
            else
            {
                int lheight = height(root.Left);
                int rheight = height(root.Right);
                if (lheight > rheight) return (lheight + 1);
                else return(rheight + 1);
            }
        }

        public virtual void printLevelOrder(TreeNode root)
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
    }
}
