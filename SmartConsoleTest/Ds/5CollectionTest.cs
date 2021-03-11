using System;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class CollectionTest
    {
        public void InitilizeArr()
        {

            bool[] strArr = new bool[5];
            string[] strArr1 = new string[] { "ja", "tu" };
            string[] strArr2 = { "ja", "tu" };
        }
        public void TypsOfArr()
        {
            int[] arr = new int[] { 5, 7 };
            int[][] jaggedArr = new int[3][];
            int[,] twoDArr = new int[3, 3];
            jaggedArr[0] = new int[3] { 1, 2, 3 };
            jaggedArr[1] = new int[3] { 4, 5, 6 };
            jaggedArr[2] = new int[3] { 7, 8, 9 };
            int left_to_right = 0;
            int reght_to_left = 0;
            int row = jaggedArr.Length;
            int columns = jaggedArr[0].Length;
            int i = 0;
            int j = 0;
            int k = 0;
            int l = jaggedArr.Length - 1;
            while (i < row && j < columns && k < row && l >= 0)
            {
                left_to_right += jaggedArr[i][j];
                reght_to_left += jaggedArr[k][l];
                i++;
                j++;
                k++;
                l--;
            }

            Console.WriteLine(Math.Abs(left_to_right - reght_to_left));

        }

        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();

            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
        public void HashSet()
        {
            HashSet<int> my_first_hashSet = new HashSet<int>();

            if (my_first_hashSet.Contains(9))
            {
                my_first_hashSet.Remove(9);
            }
            else
            {
                my_first_hashSet.Add(9);
            }

        }

    }

    public class MyLinkList
    {

        // A linked list Node 
        private class Node
        {
            public int data;
            public Node nextNode;

            // inserting the required data  
            public Node(int data) => this.data = data;
        }

        // function to create and return a Node  
        static Node GetNode(int data) => new Node(data);

        // function to insert a Node at required position  
        static Node InsertPos(Node headNode,
                            int position, int data)
        {
            var head = headNode;
            if (position < 1)
                Console.WriteLine("Invalid position");

            //if position is 1 then new node is  
            // set infornt of head node 
            //head node is changing. 
            if (position == 1)
            {
                var newNode = new Node(data);
                newNode.nextNode = headNode;
                head = newNode;
            }
            else
            {
                while (position-- != 0)
                {
                    if (position == 1)
                    {
                        // adding Node at required position 
                        Node newNode = GetNode(data);

                        // Making the new Node to point to  
                        // the old Node at the same position  
                        newNode.nextNode = headNode.nextNode;

                        // Replacing current with new Node  
                        // to the old Node to point to the new Node  
                        headNode.nextNode = newNode;
                        break;
                    }
                    headNode = headNode.nextNode;
                }
                if (position != 1)
                    Console.WriteLine("Position out of range");
            }
            return head;
        }

        static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.Write(node.data);
                node = node.nextNode;
                if (node != null)
                    Console.Write(",");
            }
            Console.WriteLine();
        }
        [Fact]
        public void LinkListTest()
        {

            var head = GetNode(3);
            head.nextNode = GetNode(5);
            head.nextNode.nextNode = GetNode(8);
            head.nextNode.nextNode.nextNode = GetNode(10);

            Console.WriteLine("Linked list before insertion: ");
            PrintList(head);

            int data = 12, pos = 3;
            head = InsertPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 12 at position 3: ");
            PrintList(head);

            // front of the linked list  
            data = 1; pos = 1;
            head = InsertPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            "insertion of 1 at position 1: ");
            PrintList(head);

            // insetion at end of the linked list  
            data = 15; pos = 7;
            head = InsertPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 15 at position 7: ");
            PrintList(head);
        }
    }

}
