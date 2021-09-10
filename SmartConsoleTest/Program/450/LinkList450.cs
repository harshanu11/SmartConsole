using System;
using System.Collections.Generic;
using Xunit;

namespace DSA450
{
    public class LinkList450 {
        #region Write a Program to reverse the Linked List. (Both Iterative and recursive)
        [Fact]
        public void LLReverseTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(new LinkedList<int>().AddLast(85));
            list.AddLast(new LinkedList<int>().AddLast(15));
            list.AddLast(new LinkedList<int>().AddLast(4));
            list.AddLast(new LinkedList<int>().AddLast(20));

            // List before reversal
            Console.WriteLine("Given linked list:");
            //PrintList();

            // Reverse the list
            //SReverseList();

            // List after reversal
            Console.WriteLine("Reversed linked list:");
            //list.PrintList();
        }

        #endregion
        #region Reverse a Linked List in group of Given Size. [Very Imp]
        ////LLNode head; // head of list

        ///* Linked list Node*/
        //class LLNode
        //{
        //    public int data;
        //    public Node next;
        //    public LLNode(int d)
        //    {
        //        data = d;
        //        next = null;
        //    }
        //}

        //LLNode reverse(LLNode head, int k)
        //{
        //    if (head == null)
        //        return null;
        //    LLNode current = head;
        //    LLNode next = null;
        //    LLNode prev = null;

        //    int count = 0;

        //    /* Reverse first k nodes of linked list */
        //    while (count < k && current != null)
        //    {
        //        next = current.next;
        //        current.next = prev;
        //        prev = current;
        //        current = next;
        //        count++;
        //    }

        //    /* next is now a pointer to (k+1)th node
        //        Recursively call for the list starting from
        //    current. And make rest of the list as next of
        //    first node */
        //    if (next != null)
        //        head.next = reverse(next, k);

        //    // prev is now head of input list
        //    return prev;
        //}

        ///* Utility functions */

        ///* Inserts a new Node at front of the list. */
        //public void push(int new_data)
        //{
        //    /* 1 & 2: Allocate the Node &
        //            Put in the data*/
        //    Node new_node = new Node(new_data);

        //    /* 3. Make next of new Node as head */
        //    new_node.next = head;

        //    /* 4. Move the head to point to new Node */
        //    head = new_node;
        //}

        ///* Function to print linked list */
        //void printList()
        //{
        //    Node temp = head;
        //    while (temp != null)
        //    {
        //        Console.Write(temp.data + " ");
        //        temp = temp.next;
        //    }
        //    Console.WriteLine();
        //}

        ///* Driver code*/
        //public static void Main(String[] args)
        //{
        //    LinkedList llist = new LinkedList();

        //    /* Constructed Linked List is 1->2->3->4->5->6->
        //    7->8->8->9->null */
        //    llist.push(9);
        //    llist.push(8);
        //    llist.push(7);
        //    llist.push(6);
        //    llist.push(5);
        //    llist.push(4);
        //    llist.push(3);
        //    llist.push(2);
        //    llist.push(1);

        //    Console.WriteLine("Given Linked List");
        //    llist.printList();

        //    llist.head = llist.reverse(llist.head, 3);

        //    Console.WriteLine("Reversed list");
        //    llist.printList();
        //}
        #endregion
        #region Write a program to Detect loop in a linked list.
        //public bool detectLoop(Node head)
        //{
        //    //using two pointers and moving one pointer(slow) by one node and 
        //    //another pointer(fast) by two nodes in each iteration.
        //    Node fast = head.next;
        //    Node slow = head;

        //    while (fast != slow)
        //    {
        //        //if the node pointed by first pointer(fast) or the node 
        //        //next to it is null, we return false.
        //        if (fast == null || fast.next == null)
        //            return false;

        //        fast = fast.next.next;
        //        slow = slow.next;
        //    }
        //    //if we reach here it means both the pointers fast and slow point to 
        //    //same node which shows the presence of loop so we return true.
        //    return true;
        //}

        #endregion
        #region Write a program to Delete loop in a linked list.
        //Complete this function
        //public void removeLoop(Node head)
        //{
        //    //using two pointers and moving one pointer(slow) by one node and 
        //    //another pointer(fast) by two nodes in each iteration.
        //    Node fast = head.next;
        //    Node slow = head;

        //    while (fast != slow)
        //    {
        //        //if the node pointed by first pointer(fast) or the node 
        //        //next to it is null, then loop is not present so we return 0.
        //        if (fast == null || fast.next == null)
        //            return;

        //        fast = fast.next.next;
        //        slow = slow.next;
        //    }
        //    //both pointers now point to the same node in the loop.

        //    int size = 1;
        //    fast = fast.next;
        //    //we start iterating the loop with first pointer and continue till 
        //    //both pointers point to same node again.
        //    while (fast != slow)
        //    {
        //        fast = fast.next;
        //        //incrementing the counter which stores length of loop..
        //        size += 1;
        //    }

        //    //updating the pointers again to starting node.
        //    slow = head;
        //    fast = head;

        //    //moving pointer (fast) by (size-1) nodes.
        //    for (int i = 0; i < size - 1; i++)
        //        fast = fast.next;

        //    //now we keep iterating with both pointers till fast reaches a node such
        //    //that the next node is pointed by slow. At this situation slow is at
        //    //the node where loop starts and first at last node so we simply 
        //    //update the link part of first.
        //    while (fast.next != slow)
        //    {
        //        fast = fast.next;
        //        slow = slow.next;
        //    }
        //    //storing null in link part of the last node.
        //    fast.next = null;
        //}
        #endregion
        #region Find the starting point of the loop. 

        //class Node
        //{
        //    public int key;
        //    public Node next;
        //};

        //static Node newNode(int key)
        //{
        //    Node temp = new Node();
        //    temp.key = key;
        //    temp.next = null;
        //    return temp;
        //}

        //// A utility function to
        //// print a linked list
        //static void printList(Node head)
        //{
        //    while (head != null)
        //    {
        //        Console.Write(head.key + " ");
        //        head = head.next;
        //    }
        //    Console.WriteLine();
        //}

        //// Function to detect and remove loop
        //// in a linked list that may contain loop
        //static Node detectAndRemoveLoop(Node head)
        //{
        //    // If list is empty or has
        //    // only one node without loop
        //    if (head == null || head.next == null)
        //        return null;

        //    Node slow = head, fast = head;

        //    // Move slow and fast 1
        //    // and 2 steps ahead
        //    // respectively.
        //    slow = slow.next;
        //    fast = fast.next.next;

        //    // Search for loop using
        //    // slow and fast pointers
        //    while (fast != null &&
        //            fast.next != null)
        //    {
        //        if (slow == fast)
        //            break;
        //        slow = slow.next;
        //        fast = fast.next.next;
        //    }

        //    // If loop does not exist
        //    if (slow != fast)
        //        return null;

        //    // If loop exists. Start slow from
        //    // head and fast from meeting point.
        //    slow = head;
        //    while (slow != fast)
        //    {
        //        slow = slow.next;
        //        fast = fast.next;
        //    }

        //    return slow;
        //}

        //// Driver code
        //public static void Main(String[] args)
        //{
        //    Node head = newNode(50);
        //    head.next = newNode(20);
        //    head.next.next = newNode(15);
        //    head.next.next.next = newNode(4);
        //    head.next.next.next.next = newNode(10);

        //    // Create a loop for testing
        //    head.next.next.next.next.next =
        //                        head.next.next;

        //    Node res = detectAndRemoveLoop(head);

        //    if (res == null)
        //        Console.Write("Loop does not exist");
        //    else
        //        Console.Write("Loop starting node is " +
        //                    res.key);
        //}
        #endregion
    }
}
