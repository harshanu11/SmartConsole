using System;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class LinkListTest
    {
        LinkListOps llo = new LinkListOps();
        [Fact]
        public void InbuiltLL() {
            // Create the link list.
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            llo.Display(sentence, "The linked list values:");
            Console.WriteLine("sentence.Contains(\"jumps\") = {0}",
                sentence.Contains("jumps"));

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            llo.Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            llo.Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            llo.Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            llo.Display(sentence, "Test 4: Move last node to be first node:");

            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            llo.IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            llo.IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            llo.IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            llo.IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            llo.IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.
            Console.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                sentence.AddBefore(current, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception message: {0}", ex.Message);
            }
            Console.WriteLine();

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            llo.IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            llo.IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            llo.IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            llo.Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            llo.Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            Console.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the linked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }

            // Release all the nodes.
            sentence.Clear();

            Console.WriteLine();
            Console.WriteLine("Test 17: Clear linked list. Contains 'jumps' = {0}",
                sentence.Contains("jumps"));
        }
    
        [Fact]
        public void LinkLisAppendToTailtTest()
        {
            LLNode MyLinkList = new LLNode(6);
            llo.appendToTail(MyLinkList, 464);
            llo.appendToTail(MyLinkList, 324);
            llo.appendToTail(MyLinkList, 322434324);
        }

        [Fact]
        public void LinkListInsertAtSpecificPosTest()
        {

            var head = llo.GetNode(3);
            head.nextNode = llo.GetNode(5);
            head.nextNode.nextNode = llo.GetNode(8);
            head.nextNode.nextNode.nextNode = llo.GetNode(10);

            Console.WriteLine("Linked list before insertion: ");
            llo.PrintList(head);

            int data = 12, pos = 3;
            head = llo.InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 12 at position 3: ");
            llo.PrintList(head);

            // front of the linked list  
            data = 1; pos = 1;
            head = llo.InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            "insertion of 1 at position 1: ");
            llo.PrintList(head);

            // insetion at end of the linked list  
            data = 15; pos = 7;
            head = llo.InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 15 at position 7: ");
            llo.PrintList(head);
        }
        [Fact]
        public void LinkListInsertAtSpecificPos_nick_white_Test()
        {

            var head = llo.GetNode(3);
            head.nextNode = llo.GetNode(5);
            head.nextNode.nextNode = llo.GetNode(8);
            head.nextNode.nextNode.nextNode = llo.GetNode(10);

            Console.WriteLine("Linked list before insertion: ");
            llo.PrintList(head);

            int data = 12, pos = 3;
            head = llo.InsertAtSpecificPos_NickWhite(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 12 at position 3: ");
            llo.PrintList(head);

            // front of the linked list  
            data = 1; pos = 1;
            head = llo.InsertAtSpecificPos_NickWhite(head, pos, data);
            Console.WriteLine("Linked list after" +
                            "insertion of 1 at position 1: ");
            llo.PrintList(head);

            // insetion at end of the linked list  
            data = 15; pos = 7;
            head = llo.InsertAtSpecificPos_NickWhite(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 15 at position 7: ");
            llo.PrintList(head);
        }
        
    }
}


