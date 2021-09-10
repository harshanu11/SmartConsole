using System.Diagnostics;
using System;
using System.Collections.Generic;
using Xunit;
using CollectionTest;

namespace DSA450
{
    public class LinkList450
    {
        #region Write a Program to reverse the Linked List. (Both Iterative and recursive)
        LLNode head;
        public void ReverseList()
        {
            LLNode prev = null, current = head, next = null;
            while (current != null)
            {
                next = current.nextNode;
                current.nextNode = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }
        void AddNode(LLNode node)
        {
            if (head == null)
                head = node;
            else
            {
                LLNode temp = head;
                while (temp.nextNode != null)
                {
                    temp = temp.nextNode;
                }
                temp.nextNode = node;
            }
        }
        [Fact]
        public void LLReverseTest()
        {
            AddNode(new LLNode(85));
            AddNode(new LLNode(15));
            AddNode(new LLNode(4));
            AddNode(new LLNode(20));
            Console.WriteLine("Given linked list:");
            ReverseList();
            Console.WriteLine("Reversed linked list:");
        }

        #endregion
        #region Reverse a Linked List in group of Given Size. [Very Imp]
        LLNode reverse(LLNode head, int k)
        {
            if (head == null)
                return null;
            LLNode current = head;
            LLNode next = null;
            LLNode prev = null;
            int count = 0;
            while (count < k && current != null)
            {
                next = current.nextNode;
                current.nextNode = prev;
                prev = current;
                current = next;
                count++;
            }
            if (next != null)
                head.nextNode = reverse(next, k);
            return prev;
        }
        void push(int new_data)
        {
            LLNode new_node = new LLNode(new_data);
            new_node.nextNode = head;
            head = new_node;
        }

        [Fact]
        public void reverseTest()
        {
            push(9);
            push(8);
            push(7);
            push(6);
            push(5);
            push(4);
            push(3);
            push(2);
            push(1);
            head = reverse(head, 3);
        }
        #endregion
        #region Write a program to Detect loop in a linked list.
        public bool detectLoopPointer(LLNode head)
        {
            LLNode fast = head.nextNode;
            LLNode slow = head;

            while (fast != slow)
            {
                if (fast == null || fast.nextNode == null)
                    return false;

                fast = fast.nextNode.nextNode;
                slow = slow.nextNode;
            }
            return true;
        }
        public static bool detectLoopHash(LLNode h)
        {
            HashSet<LLNode> s = new HashSet<LLNode>();
            while (h != null)
            {
                if (s.Contains(h))
                    return true;
                s.Add(h);

                h = h.nextNode;
            }
            return false;
        }
        [Fact]
        public void detectLoopTest()
        {
            push(20);
            push(4);
            push(15);
            push(10);

            /*Create loop for testing */
            head.nextNode.nextNode.nextNode.nextNode = head;

            if (detectLoopHash(head))
                Console.WriteLine("Loop found");
            else
                Console.WriteLine("No Loop");
        }
        #endregion
        #region Write a program to Delete loop in a linked list.
        static bool removeLoopHash(LLNode h)
        {
            HashSet<LLNode> s = new HashSet<LLNode>();
            LLNode prev = null;
            while (h != null)
            {
                if (s.Contains(h))
                {
                    prev.nextNode = null;
                    return true;
                }
                else
                {
                    s.Add(h);
                    prev = h;
                    h = h.nextNode;
                }
            }
            return false;
        }

        void removeLoop(LLNode head)
        {
            LLNode fast = head.nextNode;
            LLNode slow = head;

            while (fast != slow)
            {
                if (fast == null || fast.nextNode == null)
                    return;

                fast = fast.nextNode.nextNode;
                slow = slow.nextNode;
            }

            int size = 1;
            fast = fast.nextNode;
            while (fast != slow)
            {
                fast = fast.nextNode;
                size += 1;
            }

            slow = head;
            fast = head;
            for (int i = 0; i < size - 1; i++)
                fast = fast.nextNode;

            while (fast.nextNode != slow)
            {
                fast = fast.nextNode;
                slow = slow.nextNode;
            }
            fast.nextNode = null;
        }
        [Fact]
        public void MaDeleteLoopTestin()
        {
            head = new LLNode(50);
            head.nextNode = new LLNode(20);
            head.nextNode.nextNode = new LLNode(15);
            head.nextNode.nextNode.nextNode = new LLNode(4);
            head.nextNode.nextNode.nextNode.nextNode = new LLNode(10);
            head.nextNode.nextNode.nextNode.nextNode.nextNode = head.nextNode.nextNode;
            removeLoop(head);
            Console.WriteLine("Linked List after removing loop : ");
        }
        #endregion
        #region Find the starting point of the loop. 


        static LLNode newNode(int key)
        {
            LLNode temp = new LLNode(0);
            temp.data = key;
            temp.nextNode = null;
            return temp;
        }

        static LLNode detectAndRemoveLoop(LLNode head)
        {
            if (head == null || head.nextNode == null)
                return null;
            LLNode slow = head, fast = head;
            slow = slow.nextNode;
            fast = fast.nextNode.nextNode;
            while (fast != null && fast.nextNode != null)
            {
                if (slow == fast)
                    break;
                slow = slow.nextNode;
                fast = fast.nextNode.nextNode;
            }
            if (slow != fast)
                return null;
            slow = head;
            while (slow != fast)
            {
                slow = slow.nextNode;
                fast = fast.nextNode;
            }
            return slow;
        }
        [Fact]
        public void detectAndRemoveLoopTest()
        {
            head.nextNode = newNode(20);
            head.nextNode.nextNode = newNode(15);
            head.nextNode.nextNode.nextNode = newNode(4);
            head.nextNode.nextNode.nextNode.nextNode = newNode(10);
            head.nextNode.nextNode.nextNode.nextNode.nextNode = head.nextNode.nextNode;
            LLNode res = detectAndRemoveLoop(head);

            if (res == null)
                Debug.Write("Loop does not exist");
            else
                Debug.Write("Loop starting node is " + res.data);
        }
        #endregion
    }
}
