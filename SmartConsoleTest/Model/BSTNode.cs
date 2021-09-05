namespace CollectionTest
{
    public class BSTNode
    {
        public int Data;
        public BSTNode Left;
        public BSTNode Right;
        public BSTNode()
        {

        }
        public BSTNode(int data)
        {
            this.Data = data;
            Left = Right = null;
        }
        public BSTNode Insert(BSTNode root,int data) 
        {
            if (root.Data == null)
            {
                root = new BSTNode();
            }
            if (root.Data > data)
            {
                root.Left = Insert(root.Left,data);
            }
            else if (root.Data < data)
            {
                root.Right = Insert(root.Right,data);
            }
            return root;
        }
    }
}
