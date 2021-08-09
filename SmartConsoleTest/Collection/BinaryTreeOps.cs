namespace CollectionTest
{
    public class BinaryTreeOps
    {
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
                if (data <=root.Data)
                {
                    current = Insert(root.Left,data);
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
