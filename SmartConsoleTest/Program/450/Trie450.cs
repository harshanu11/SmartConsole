using System;
using System.Collections.Generic;
using Xunit;

namespace SmartConsoleTest.Program._450
{
    public class Trie450 
    {
        #region Construct a trie from scratch
        public class Trie
        {
            static readonly int ALPHABET_SIZE = 26;
            class TrieNode
            {
                public TrieNode[] children = new TrieNode[ALPHABET_SIZE];

                // isEndOfWord is true if the node represents
                // end of a word
                public bool isEndOfWord;

                public TrieNode()
                {
                    isEndOfWord = false;
                    for (int i = 0; i < ALPHABET_SIZE; i++)
                        children[i] = null;
                }
            };
            static TrieNode root;
            static void insert(String key)
            {
                int level;
                int length = key.Length;
                int index;

                TrieNode pCrawl = root;

                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a';
                    if (pCrawl.children[index] == null)
                        pCrawl.children[index] = new TrieNode();

                    pCrawl = pCrawl.children[index];
                }

                // mark last node as leaf
                pCrawl.isEndOfWord = true;
            }
            static bool search(String key)
            {
                int level;
                int length = key.Length;
                int index;
                TrieNode pCrawl = root;

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
            public static void CreateTrie()
            {
                // Input keys (use only 'a'
                // through 'z' and lower case)
                String[] keys = {"the", "a", "there", "answer",
                        "any", "by", "bye", "their"};

                String[] output = { "Not present in trie", "Present in trie" };


                root = new TrieNode();

                // Construct trie
                int i;
                for (i = 0; i < keys.Length; i++)
                    insert(keys[i]);

                // Search for different keys
                if (search("the") == true)
                    Console.WriteLine("the --- " + output[1]);
                else Console.WriteLine("the --- " + output[0]);

                if (search("these") == true)
                    Console.WriteLine("these --- " + output[1]);
                else Console.WriteLine("these --- " + output[0]);

                if (search("their") == true)
                    Console.WriteLine("their --- " + output[1]);
                else Console.WriteLine("their --- " + output[0]);

                if (search("thaw") == true)
                    Console.WriteLine("thaw --- " + output[1]);
                else Console.WriteLine("thaw --- " + output[0]);

            }
        }
        #endregion
        #region Find shortest unique prefix for every word in a given list
        public class Unique_Prefix_Trie
        {

            static readonly int MAX = 256;

            // Maximum length of an input word
            static readonly int MAX_WORD_LEN = 500;

            // Trie Node.
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

            // Method to insert a new string into Trie
            static void insert(String str)
            {
                // Length of the URL
                int len = str.Length;
                TrieNode pCrawl = root;

                // Traversing over the length of given str.
                for (int level = 0; level < len; level++)
                {
                    // Get index of child node from
                    // current character in str.
                    int index = str[level];

                    // Create a new child if not exist already
                    if (pCrawl.child[index] == null)
                        pCrawl.child[index] = new TrieNode();
                    else
                        (pCrawl.child[index].freq)++;

                    // Move to the child
                    pCrawl = pCrawl.child[index];
                }
            }
            static void findPrefixesUtil(TrieNode root, char[] prefix,
                                int ind)
            {
                // Corner case
                if (root == null)
                    return;

                // Base case
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
                // Construct a Trie of all words
                root = new TrieNode();
                root.freq = 0;
                for (int i = 0; i < n; i++)
                    insert(arr[i]);

                // Create an array to store all prefixes
                char[] prefix = new char[MAX_WORD_LEN];

                // Print all prefixes using Trie Traversal
                findPrefixesUtil(root, prefix, 0);
            }

            // Driver code
            public static void Main()
            {
                String[] arr = { "zebra", "dog", "duck", "dove" };
                int n = arr.Length;
                findPrefixes(arr, n);
            }
        }
        #endregion
        #region Word Break Problem | (Trie solution)
        internal const int ALPHABET_SIZE = 26;

        // trie node
        internal class TrieNode
        {
            internal TrieNode[] children;

            // isEndOfWord is true if the node
            // represents end of a word
            internal bool isEndOfWord;

            // Constructor of TrieNode
            internal TrieNode()
            {
                children = new TrieNode[ALPHABET_SIZE];
                for (int i = 0; i < ALPHABET_SIZE; i++)
                {
                    children[i] = null;
                }

                isEndOfWord = false;
            }
        }
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

            // Mark last node as leaf
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

            // Base case
            if (size == 0)
            {
                return true;
            }

            // Try all prefixes of lengths from 1 to size
            for (int i = 1; i <= size; i++)
            {

                // The parameter for search is
                // str.substring(0, i)
                // str.substrinf(0, i) which is
                // prefix (of input string) of
                // length 'i'. We first check whether
                // current prefix is in dictionary.
                // Then we recursively check for remaining
                // string str.substr(i, size) which
                // is suffix of length size-i.
                if (search(root, str.Substring(0, i)) && wordBreak(str.Substring(i, size - i), root))
                {
                    return true;
                }
            }

            // If we have tried all prefixes and none
            // of them worked
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
                // Convert the string to its lexicographically 
                // least representation, 
                // e.g. cat->act, act->act, tac->act 
                string s = new string(ch);

                // Check if that representation has 
                // occurred already
                if (mp.ContainsKey(s))
                {
                    // If occurred add the original string to the map
                    mp[s].Add(i);
                }

                // If not present
                else
                {
                    // Create a new list
                    IList<string> li = new List<string>();
                    // Add the original string
                    li.Add(i);
                    ans.Add(li);
                    // Insert into the map the string as key 
                    // and the new list as value
                    mp[s] = li;
                }
            }

            return ans;

        }

        #endregion
        #region Implement a Phone Directory
        public class TrieNode1
        {

            public Dictionary<char, TrieNode1> child;

            public bool isLast;

            // Default Constructor
            public TrieNode1()
            {
                child = new Dictionary<char, TrieNode1>();
                for (char i = 'a'; i <= 'z'; i++)
                    child.Add(i, null);
                isLast = false;
            }
        }

        public class Trie1
        {
            public TrieNode1 root;

            // Insert all the Contacts into the Trie
            public void insertIntoTrie(String[] contacts)
            {
                root = new TrieNode1();
                int n = contacts.Length;
                for (int i = 0; i < n; i++)
                {
                    insert(contacts[i]);
                }
            }

            // Insert a Contact into the Trie
            public void insert(String s)
            {
                int len = s.Length;

                // 'itr' is used to iterate the Trie Nodes
                TrieNode1 itr = root;
                for (int i = 0; i < len; i++)
                {
                    // Check if the s[i] is already present in
                    // Trie
                    TrieNode1 nextNode = itr.child[s[i]];
                    if (nextNode == null)
                    {
                        // If not found then create a new TrieNode
                        nextNode = new TrieNode1();

                        // Insert into the Dictionary
                        if (itr.child.ContainsKey(s[i]))
                            itr.child[s[i]] = nextNode;
                        else
                            itr.child.Add(s[i], nextNode);
                    }

                    // Move the iterator('itr') ,to point to next
                    // Trie Node
                    itr = nextNode;

                    // If its the last character of the string 's'
                    // then mark 'isLast' as true
                    if (i == len - 1)
                        itr.isLast = true;
                }
            }

            // This function simply displays all dictionary words
            // going through current node. String 'prefix'
            // represents string corresponding to the path from
            // root to curNode.
            public void displayContactsUtil(TrieNode1 curNode,
                                            String prefix)
            {

                // Check if the string 'prefix' ends at this Node
                // If yes then display the string found so far
                if (curNode.isLast)
                    Console.WriteLine(prefix);

                // Find all the adjacent Nodes to the current
                // Node and then call the function recursively
                // This is similar to performing DFS on a graph
                for (char i = 'a'; i <= 'z'; i++)
                {
                    TrieNode1 nextNode = curNode.child[i];
                    if (nextNode != null)
                    {
                        displayContactsUtil(nextNode, prefix + i);
                    }
                }
            }

            // Display suggestions after every character enter by
            // the user for a given string 'str'
            //public void displayContacts(String str)
            //{
            //    TrieNode1 prevNode = root;

            //    // 'flag' denotes whether the string entered
            //    // so far is present in the Contact List

            //    String prefix = "";
            //    int len = str.Length;

            //    // Display the contact List for string formed
            //    // after entering every character
            //    int i;
            //    for (i = 0; i < len; i++)
            //    {
            //        // 'str' stores the string entered so far
            //        prefix += str[i];

            //        // Get the last character entered
            //        char lastChar = prefix[i];

            //        // Find the Node corresponding to the last
            //        // character of 'str' which is pointed by
            //        // prevNode of the Trie
            //        TrieNode curNode = prevNode.child[lastChar];

            //        // If nothing found, then break the loop as
            //        // no more prefixes are going to be present.
            //        if (curNode == null)
            //        {
            //            Console.WriteLine("\nNo Results Found for'"
            //                                    + prefix + "'");
            //            i++;
            //            break;
            //        }

            //        // If present in trie then display all
            //        // the contacts with given prefix.
            //        Console.WriteLine("Suggestions based on '"
            //                            + prefix + "' are");
            //        displayContactsUtil(curNode, prefix);

            //        // Change prevNode for next prefix
            //        prevNode = curNode;
            //    }

            //    for (; i < len; i++)
            //    {
            //        prefix += str[i];
            //        Console.WriteLine("\nNo Results Found for '"
            //                                    + prefix + "'");
            //    }
            //}
        }

        [Fact]
        public void PhoneDirectoryTest()
        {
            Trie1 trie = new Trie1();

            String[] contacts = { "gforgeeks", "geeksquiz" };

            trie.insertIntoTrie(contacts);

            String query = "gekk";

            // Note that the user will enter 'g' then 'e' so
            // first display all the strings with prefix as 'g'
            // and then all the strings with prefix as 'ge'
            //trie.displayContacts(query);
        }
        #endregion
        #region Print unique rows in a given boolean matrix
        static int ROW = 4;
        static int COL = 5;

        // Function that prints all  
        // unique rows in a given matrix. 
        static void findUniqueRows(int[,] M)
        {

            // Traverse through the matrix 
            for (int i = 0; i < ROW; i++)
            {
                int flag = 0;

                // Check if there is similar column 
                // is already printed, i.e if i and 
                // jth column match. 
                for (int j = 0; j < i; j++)
                {
                    flag = 1;

                    for (int k = 0; k < COL; k++)
                        if (M[i, k] != M[j, k])
                            flag = 0;

                    if (flag == 1)
                        break;
                }

                // If no row is similar 
                if (flag == 0)
                {

                    // Print the row 
                    for (int j = 0; j < COL; j++)
                        Console.Write(M[i, j] + " ");

                    Console.WriteLine();
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
