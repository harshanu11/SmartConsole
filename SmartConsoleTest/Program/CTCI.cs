using CollectionTest;
using System;
using System.Linq;
using Xunit;

namespace SmartConsoleTest.Program
{
    public class CTCI
    {
        #region ArrayStr


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
                    Console.WriteLine((char)i);
                }
            }
        }
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

            Console.WriteLine(ans);
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
            Console.WriteLine(ch.Length + (3 * 2));
            bool ans = true;
            int count1 = 0;
            for (int i = 0; i < ch1.Length-2; i++)
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

            Console.WriteLine(new String(ch1));
        }

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
                        Console.WriteLine((char)i);
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

            Console.WriteLine(oneEditCount);
        }
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
                Console.WriteLine(input);
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
                Console.WriteLine(outPut);
            }
        }
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
                    Console.Write(imgArr[i, j]);
                }
                Console.WriteLine();
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
            Console.WriteLine("---------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(imgArr[i, j]);
                }
                Console.WriteLine();

            }

        }
        public void CheckRotatedStrong()
        {
            string str1 = "waterbottle"; string strTest = "ottlewaterb";

            string[] strCollection = new string[str1.Length];
            //Console.WriteLine(str1);
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
            Console.WriteLine(isRotated);
        }
        #endregion
        #region LinkList
        public static LL RemoveSpecificDuplicate(LL head, int d)
        {
            LL n = head;
            if (head.data == d)
            {
                return head.next;
            }

            while (n.next != null)
            {
                if (n.next.data == d)
                {
                    n.next = n.next.next;
                }
                n = n.next;
            }

            return head;
        }
        public static int FindKthFromEnd(LL head, int k)
        {
            int LengthOfLL = 0;
            int response = 0;
            LL n = head;
            while (n.next != null)
            {
                LengthOfLL++;
                n = n.next;
            }
            int countFromStart = LengthOfLL - k;
            int counter = 0;
            Console.WriteLine(countFromStart);

            while (head.next != null)
            {
                if (counter == countFromStart)
                {
                    Console.WriteLine(head.data);
                    break;
                }
                counter++;
                head = head.next;
            }


            return response;
        }
        #endregion
    }
}
