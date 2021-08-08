namespace CollectionTest
{
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
    }
}
