using System.Collections.Generic;

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
    }
    public class TrieNode1
    {
        public Dictionary<char, TrieNode1> child;
        public bool isLast;
        public TrieNode1()
        {
            child = new Dictionary<char, TrieNode1>();
            for (char i = 'a'; i <= 'z'; i++)
                child.Add(i, null);
            isLast = false;
        }
    }
}
