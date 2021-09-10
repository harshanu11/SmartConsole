namespace CollectionTest
{
    public class LLNode
    {
        public int data;
        public LLNode nextNode;

        public LLNode(int data) => this.data = data;
    }
    public class DLLNode
    {
        public DLLNode prev;
        public int data;
        public DLLNode next;
        public DLLNode(int d) { data = d; }
    }
}


