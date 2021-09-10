using System.Diagnostics;
using CollectionTest;
using System;
using System.Linq;
using Xunit;

namespace CTCINs
{
    public class CTCI
    {
        #region ArrayStr

        [Fact]
        public void CheckDuplicateStr()
        {
            int[] c = new int[128];

            string str = "afhsdfsahhlsadf";
            for (int i = 0; i < str.Length; i++)
            {
                c[str[i]]++;
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] > 0)
                {
                    Debug.WriteLine((char)i);
                }
            }
        }
        [Fact]
        public void CheckPermutationstr()
        {
            int[] c = new int[128];
            int[] c1 = new int[128];
            string str = "afhsdfsahhlsadf";
            string str1 = "afhsdfsahhlsadf";
            for (int i = 0; i < str.Length; i++)
            {
                c[str[i]]++;
                c1[str1[i]]++;
            }
            bool ans = true;
            for (int i = 0; i < c.Length; i++)
            {
                if (str.Length == str1.Length && c[i] != c1[i])
                {
                    ans = false;
                    break;
                }
            }

            Debug.WriteLine(ans);
        }
        [Fact]
        public void FindReplaceTesr()
        {
            int[] c = new int[128];

            string str = "Mr 3ohn Smith";
            char[] ch = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    count++;
                }
            }
            char[] ch1 = new char[ch.Length + (3 * 2)];
            Debug.WriteLine(ch.Length + (3 * 2));
            bool ans = true;
            int count1 = 0;
            for (int i = 0; i < ch1.Length - 2; i++)
            {
                if (ch1[count1] == ' ')
                {
                    //count++;
                    ch1[i] = '%';
                    ch1[i + 1] = '2';
                    ch1[i + 2] = '0';
                    i = i + 2;
                }
                else
                {
                    //ch1[i] = ch[count1];
                }

                count1++;
            }

            Debug.WriteLine(new String(ch1));
        }
        [Fact]
        public void IsPalandromTest()
        {

            string inputPalan = "1234 4321";
            bool isPalandrom = true;
            for (int i = 0; i < inputPalan.Length / 2; i++)
            {
                if (inputPalan[i] != inputPalan[inputPalan.Length - 1 - i])
                {
                    isPalandrom = false;
                    break;
                }
            }
        }
        [Fact]
        public void PringMissingItemFormString()
        {
            string strOne = "Pale";
            string strTwo = "Pl";
            //string strOne = "Pale";
            //string strTwo = "Palx";
            bool oneEditCount = true;
            int editCount = 0;
            if (strOne.Length == strTwo.Length)
            {
                for (int i = 0; i < strOne.Length; i++)
                {
                    if (strOne[i] != strTwo[i])
                    {
                        editCount++;
                        if (editCount > 1)
                        {
                            oneEditCount = false;
                            break;
                        }
                    }
                }
            }
            else if (strOne.Length != strTwo.Length)
            {

                int[] alphabaet = new int[128];
                char missing = ' ';
                for (int i = 0; i < strOne.Length; i++)
                {
                    alphabaet[strOne[i]]++;
                }
                for (int i = 0; i < strTwo.Length; i++)
                {
                    alphabaet[strTwo[i]]++;
                }
                for (int i = 0; i < alphabaet.Length; i++)
                {
                    if (alphabaet[i] == 1)
                    {
                        Debug.WriteLine((char)i);
                        missing = (char)i;
                        editCount++;
                        if (editCount > 1)
                        {
                            oneEditCount = false;
                            break;
                        }
                    }
                }
            }

            Debug.WriteLine(oneEditCount);
        }
        [Fact]
        public void FindDublicateAndDubCount()
        {
            string str0 = "adflksdaf";
            string str3 = "aabcccccaaa";
            string str1 = "qwertyuiop";

            string input = str1;
            int[] alphabet = new int[128];

            for (int i = 0; i < input.Length; i++)
            {
                alphabet[input[i]]++;
            }
            bool checkDuplicate = false;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] > 1)
                {
                    checkDuplicate = true;
                    break;
                }
            }
            if (!checkDuplicate)
            {
                Debug.WriteLine(input);
            }
            else
            {
                string outPut = "";
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] > 0)
                    {
                        outPut += Convert.ToString((char)i) + alphabet[i];
                    }
                }
                Debug.WriteLine(outPut);
            }
        }
        [Fact]
        public void RotateArrByClock90()
        {

            int[,] imgArr = new int[3, 3];
            int num = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    imgArr[i, j] = num;
                    num++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Debug.Write(imgArr[i, j]);
                }
                Debug.WriteLine("");
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var temp = imgArr[i, j];
                    imgArr[i, j] = imgArr[j, i];
                    imgArr[j, i] = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3 / 2; j++)
                {
                    var temp = imgArr[i, j];
                    imgArr[i, j] = imgArr[i, 3 - j - 1];
                    imgArr[i, 3 - j - 1] = temp;
                }
            }
            Debug.WriteLine("---------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Debug.Write(imgArr[i, j]);
                }
                Debug.WriteLine("");

            }

        }
        [Fact]
        public void CheckRotatedStrong()
        {
            string str1 = "waterbottle"; string strTest = "ottlewaterb";

            string[] strCollection = new string[str1.Length];
            //Debug.WriteLine(str1);
            for (int i = 0; i < str1.Length; i++)
            {
                //var charCollection =str1.ToCharArray();
                string temp = new String(str1.Skip(1).ToArray()) + new String(str1.Take(1).ToArray());
                strCollection[i] = temp;
                str1 = temp;
            }
            bool isRotated = false;
            for (int i = 0; i < strCollection.Length; i++)
            {
                if (strTest == strCollection[i])
                {
                    isRotated = true;
                    break;
                }
            }
            Debug.WriteLine(isRotated);
        }
        #endregion
        #region LinkList

        [Fact]
        public static void RemoveSpecificDuplicateTest()
        {
            LLNode head = new LLNode(8);
            int d = 88;
            RemoveSpecificDuplicate(head, d);
        }
        public static LLNode RemoveSpecificDuplicate(LLNode head, int d)
        {
            LLNode n = head;
            if (head.data == d)
            {
                return head.nextNode;
            }

            while (n.nextNode != null)
            {
                if (n.nextNode.data == d)
                {
                    n.nextNode = n.nextNode.nextNode;
                }
                n = n.nextNode;
            }

            return head;
        }
        [Fact]
        public static void FindKthFromEndTest()
        {
            LLNode head = new LLNode(8);
            int d = 88;
            FindKthFromEnd(head, d);
        }
        public static int FindKthFromEnd(LLNode head, int k)
        {
            int LengthOfLL = 0;
            int response = 0;
            LLNode n = head;
            while (n.nextNode != null)
            {
                LengthOfLL++;
                n = n.nextNode;
            }
            int countFromStart = LengthOfLL - k;
            int counter = 0;
            Debug.WriteLine(countFromStart);

            while (head.nextNode != null)
            {
                if (counter == countFromStart)
                {
                    Debug.WriteLine(head.data);
                    break;
                }
                counter++;
                head = head.nextNode;
            }


            return response;
        }
        #endregion
    }
}
