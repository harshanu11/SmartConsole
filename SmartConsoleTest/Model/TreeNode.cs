namespace CollectionTest
{
    public class TreeNode
    {
        public int Data;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode()
        {

        }
        public TreeNode(int data)
        {
            TreeNode newNode = new TreeNode();
            newNode.Data = data;
            Left = Right = null;
        }
    }
}
