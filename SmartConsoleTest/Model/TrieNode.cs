namespace CollectionTest
{
    public class TrieNode
    {
        static readonly int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
        public bool isEndOfWord;
        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    };
}
