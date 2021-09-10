using CollectionTest;
using System;
using System.Collections.Generic;
using Xunit;
using System.Diagnostics;
namespace DSA450
{
    public class Trie450
    {
        #region Construct a trie from scratch
        TrieNode rootTrie;
        void insert(string key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = rootTrie;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            pCrawl.isEndOfWord = true;
        }
        bool search(string key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = rootTrie;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl.isEndOfWord);
        }
        [Fact]
        public void CreateTrie()
        {
            string[] keys = {"the", "a", "there", "answer","any", "by", "bye", "their"};
            string[] output = { "Not present in trie", "Present in trie" };
            rootTrie = new TrieNode();
            int i;
            for (i = 0; i < keys.Length; i++)
                insert(keys[i]);
            if (search("the") == true)
                Debug.WriteLine("the --- " + output[1]);
            else Debug.WriteLine("the --- " + output[0]);
            if (search("these") == true)
                Debug.WriteLine("these --- " + output[1]);
            else Debug.WriteLine("these --- " + output[0]);
            if (search("their") == true)
                Debug.WriteLine("their --- " + output[1]);
            else Debug.WriteLine("their --- " + output[0]);
            if (search("thaw") == true)
                Debug.WriteLine("thaw --- " + output[1]);
            else Debug.WriteLine("thaw --- " + output[0]);

        }
        #endregion
        #region Find shortest unique prefix for every word in a given list
        public class Unique_Prefix_Trie
        {
            static readonly int MAX = 256;
            static readonly int MAX_WORD_LEN = 500;
            public class TrieNode
            {
                public TrieNode[] child = new TrieNode[MAX];
                public int freq; // To store frequency
                public TrieNode()
                {
                    freq = 1;
                    for (int i = 0; i < MAX; i++)
                        child[i] = null;
                }
            }
            static TrieNode root;
            static void insert(String str)
            {
                int len = str.Length;
                TrieNode pCrawl = root;
                for (int level = 0; level < len; level++)
                {
                    int index = str[level];
                    if (pCrawl.child[index] == null)
                        pCrawl.child[index] = new TrieNode();
                    else
                        (pCrawl.child[index].freq)++;
                    pCrawl = pCrawl.child[index];
                }
            }
            static void findPrefixesUtil(TrieNode root, char[] prefix,int ind)
            {
                if (root == null)
                    return;
                if (root.freq == 1)
                {
                    prefix[ind] = '\0';
                    int i = 0;
                    while (prefix[i] != '\0')
                        Console.Write(prefix[i++]);
                    Console.Write(" ");
                    return;
                }
                for (int i = 0; i < MAX; i++)
                {
                    if (root.child[i] != null)
                    {
                        prefix[ind] = (char)i;
                        findPrefixesUtil(root.child[i], prefix, ind + 1);
                    }
                }
            }
            static void findPrefixes(String[] arr, int n)
            {
                root = new TrieNode();
                root.freq = 0;
                for (int i = 0; i < n; i++)
                    insert(arr[i]);

                // Create an array to store all prefixes
                char[] prefix = new char[MAX_WORD_LEN];

                // Print all prefixes using Trie Traversal
                findPrefixesUtil(root, prefix, 0);
            }

            [Fact]
            public static void findPrefixesTest()
            {
                String[] arr = { "zebra", "dog", "duck", "dove" };
                int n = arr.Length;
                findPrefixes(arr, n);
            }
        }
        #endregion
        #region Word Break Problem | (Trie solution)

        internal static void insert(TrieNode root, string key)
        {
            TrieNode pCrawl = root;
            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';
                if (pCrawl.children[index] == null)
                {
                    pCrawl.children[index] = new TrieNode();
                }
                pCrawl = pCrawl.children[index];
            }
            pCrawl.isEndOfWord = true;
        }
        internal static bool search(TrieNode root, string key)
        {
            TrieNode pCrawl = root;
            for (int i = 0; i < key.Length; i++)
            {
                int index = key[i] - 'a';
                if (pCrawl.children[index] == null)
                {
                    return false;
                }

                pCrawl = pCrawl.children[index];
            }
            return (pCrawl != null && pCrawl.isEndOfWord);
        }
        internal static bool wordBreak(string str, TrieNode root)
        {
            int size = str.Length;
            if (size == 0)
            {
                return true;
            }
            for (int i = 1; i <= size; i++)
            {
                if (search(root, str.Substring(0, i)) && wordBreak(str.Substring(i, size - i), root))
                {
                    return true;
                }
            }
            return false;
        }

        [Fact]
        public void wordBreakTest()
        {
            string[] dictionary = new string[] { "mobile", "samsung", "sam", "sung", "ma", "mango", "icecream", "and", "go", "i", "like", "ice", "cream" };

            int n = dictionary.Length;
            TrieNode root = new TrieNode();

            // Construct trie
            for (int i = 0; i < n; i++)
            {
                insert(root, dictionary[i]);
            }

            Console.Write(wordBreak("ilikesamsung", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("iiiiiiii", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("ilikelikeimangoiii", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("samsungandmango", root) ? "Yes\n" : "No\n");
            Console.Write(wordBreak("samsungandmangok", root) ? "Yes\n" : "No\n");
        }

        #endregion
        #region Given a sequence of words, print all anagrams together
        public virtual IList<IList<string>> Anagrams(string[] string_list)
        {

            Dictionary<string, IList<string>> mp = new Dictionary<string, IList<string>>();
            IList<IList<string>> ans = new List<IList<string>>();

            foreach (string i in string_list)
            {
                char[] ch = i.ToCharArray();
                Array.Sort(ch);
                string s = new string(ch);
                if (mp.ContainsKey(s))
                {
                    mp[s].Add(i);
                }
                else
                {
                    IList<string> li = new List<string>();
                    li.Add(i);
                    ans.Add(li);
                    mp[s] = li;
                }
            }
            return ans;
        }
        #endregion
        #region Implement a Phone Directory
        public class Trie1
        {
            public TrieNode1 root;
            public void insertIntoTrie(String[] contacts)
            {
                root = new TrieNode1();
                int n = contacts.Length;
                for (int i = 0; i < n; i++)
                {
                    insert(contacts[i]);
                }
            }
            public void insert(String s)
            {
                int len = s.Length;

                TrieNode1 itr = root;
                for (int i = 0; i < len; i++)
                {
                    TrieNode1 nextNode = itr.child[s[i]];
                    if (nextNode == null)
                    {
                        nextNode = new TrieNode1();

                        if (itr.child.ContainsKey(s[i]))
                            itr.child[s[i]] = nextNode;
                        else
                            itr.child.Add(s[i], nextNode);
                    }
                    itr = nextNode;
                    if (i == len - 1)
                        itr.isLast = true;
                }
            }
            public void displayContactsUtil(TrieNode1 curNode, String prefix)
            {
                if (curNode.isLast)
                    Debug.WriteLine(prefix);
                for (char i = 'a'; i <= 'z'; i++)
                {
                    TrieNode1 nextNode = curNode.child[i];
                    if (nextNode != null)
                    {
                        displayContactsUtil(nextNode, prefix + i);
                    }
                }
            }
            public void displayContacts(String str)
            {
                TrieNode1 prevNode = root;

                
                String prefix = "";
                int len = str.Length;

                int i;
                for (i = 0; i < len; i++)
                {
                    prefix += str[i];
                    char lastChar = prefix[i];

                    TrieNode1 curNode = prevNode.child[lastChar];
                    if (curNode == null)
                    {
                        Debug.WriteLine("\nNo Results Found for'"+ prefix + "'");
                        i++;
                        break;
                    }
                    Debug.WriteLine("Suggestions based on '"+ prefix + "' are");
                    displayContactsUtil(curNode, prefix);

                    prevNode = curNode;
                }

                for (; i < len; i++)
                {
                    prefix += str[i];
                    Debug.WriteLine("\nNo Results Found for '" + prefix + "'");
                }
            }

        }

        [Fact]
        public void PhoneDirectoryTest()
        {
            Trie1 trie = new Trie1();
            String[] contacts = { "gforgeeks", "geeksquiz" };
            trie.insertIntoTrie(contacts);
            String query = "gekk";
            trie.displayContacts(query);
        }
        #endregion
        #region Print unique rows in a given boolean matrix
        static int ROW = 4;
        static int COL = 5;
        static void findUniqueRows(int[,] M)
        {
            for (int i = 0; i < ROW; i++)
            {
                int flag = 0;

                for (int j = 0; j < i; j++)
                {
                    flag = 1;

                    for (int k = 0; k < COL; k++)
                        if (M[i, k] != M[j, k])
                            flag = 0;

                    if (flag == 1)
                        break;
                }
                if (flag == 0)
                {
                    for (int j = 0; j < COL; j++)
                        Console.Write(M[i, j] + " ");
                    Debug.WriteLine("");
                }
            }
        }

        [Fact]
        public void findUniqueRowsTest()
        {
            int[,] M = { { 0, 1, 0, 0, 1 },
                 { 1, 0, 1, 1, 0 },
                 { 0, 1, 0, 0, 1 },
                 { 1, 0, 1, 0, 0 } };

            findUniqueRows(M);
        }
        #endregion
    }
}
