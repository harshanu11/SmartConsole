using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionTest
{
    public class LinkListOps
    {
        public LLNode MiddleNode(LLNode head)
        {
            LLNode fast = head;
            LLNode slow = head;
            while (fast != null && fast.nextNode != null)
            {
                fast = fast.nextNode.nextNode;
                slow = slow.nextNode;
            }
            return slow;
        }
        public LLNode MergeTwoLists(LLNode l1, LLNode l2)
        {
            LLNode temp = new LLNode(0);
            LLNode current_node = temp;

            while (l1 != null && l2 != null)
            {
                if (l1.data < l2.data)
                {
                    current_node.nextNode = l1;
                    l1 = l1.nextNode;
                }
                else
                {
                    current_node.nextNode = l2;
                    l2 = l2.nextNode;
                }
                current_node = current_node.nextNode;
            }
            if (l1 != null)
            {
                current_node.nextNode = l1;
                l1 = l1.nextNode;
            }
            if (l2 != null)
            {
                current_node.nextNode = l2;
                l2 = l2.nextNode;
            }
            return temp.nextNode;

        }

        // function to create and return a Node  
        public LLNode GetNode(int data) => new LLNode(data);

        // function to insert a Node at required position  
        public LLNode InsertAtSpecificPos(LLNode headNode,
                            int position, int data)
        {
            var head = headNode;
            if (position < 1)
                Debug.WriteLine("Invalid position");

            //if position is 1 then new node is  
            // set infornt of head node 
            //head node is changing. 
            if (position == 1)
            {
                var newNode = new LLNode(data);
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
                        LLNode newNode = GetNode(data);

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
                    Debug.WriteLine("Position out of range");
            }
            return head;
        }

        public LLNode InsertAtSpecificPos_NickWhite(LLNode headNode,
                            int position, int data)
        {
            var newNode = new LLNode(data);
            var current_node = headNode;
            int index = 0;

            while (index < position - 2)
            {
                current_node = current_node.nextNode;
                index++;
            }

            newNode.nextNode = current_node.nextNode;
            current_node.nextNode = newNode;
            return headNode;
        }

        public void PrintList(LLNode node)
        {
            while (node != null)
            {
                Console.Write(node.data);
                node = node.nextNode;
                if (node != null)
                    Console.Write(",");
            }
            Debug.WriteLine();
        }

        public void appendToTail(LLNode nd, int d)
        {
            LLNode end = new LLNode(d);
            while (nd.nextNode != null)
            {
                nd = nd.nextNode;
            }
            nd.nextNode = end;
        }
        #region SimpleLL
        public  void addToTail(LLNode head, int data)
        {
            LLNode end = new LLNode(data);
            while (head.nextNode != null)
            {
                head = head.nextNode;
            }

            head.nextNode = end;
        }

        public  void Print(LLNode head)
        {
            while (head.nextNode != null)
            {
                head = head.nextNode;
                Debug.WriteLine(head.data);
            }
        }

        public  LLNode deleteLL(LLNode head, int data)
        {
            LLNode n = head;
            if (n.data == data)
            {
                return head.nextNode;
            }

            while (n.nextNode != null)
            {
                if (n.nextNode.data == data)
                {
                    n.nextNode = n.nextNode.nextNode;
                }
                n = n.nextNode;
            }

            return head;
        }

        #endregion
        #region InbuiltLL

        public  void Display(LinkedList<string> words, string test)
        {
            Debug.WriteLine(test);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Debug.WriteLine();
            Debug.WriteLine();
        }

        public  void IndicateNode(LinkedListNode<string> node, string test)
        {
            Debug.WriteLine(test);
            if (node.List == null)
            {
                Debug.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Debug.WriteLine(result);
            Debug.WriteLine();
        }
        #endregion
    }
}


