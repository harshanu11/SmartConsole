using System;
using Xunit;

namespace CollectionTest
{
    // A linked list Node 
    public class LLNode
    {
        public int data;
        public LLNode nextNode;

        // inserting the required data  
        public LLNode(int data) => this.data = data;
    }
    public class LinkListTest
    {

        // function to create and return a Node  
        LLNode GetNode(int data) => new LLNode(data);

        // function to insert a Node at required position  
        LLNode InsertAtSpecificPos(LLNode headNode,
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
                    Console.WriteLine("Position out of range");
            }
            return head;
        }

         void PrintList(LLNode node)
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

        void appendToTail(LLNode nd, int d)
        {
            LLNode end = new LLNode(d);
            while (nd.nextNode != null) {
                nd = nd.nextNode;
            }
            nd.nextNode = end;
        }
        [Fact]
        public void LinkLisAppendToTailtTest() 
        {
            LLNode MyLinkList = new LLNode(6);
            appendToTail(MyLinkList, 464);
            appendToTail(MyLinkList, 324);
            appendToTail(MyLinkList, 322434324);
        }

        [Fact]
        public void LinkListInsertAtSpecificPosTest()
        {

            var head = GetNode(3);
            head.nextNode = GetNode(5);
            head.nextNode.nextNode = GetNode(8);
            head.nextNode.nextNode.nextNode = GetNode(10);

            Console.WriteLine("Linked list before insertion: ");
            PrintList(head);

            int data = 12, pos = 3;
            head = InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 12 at position 3: ");
            PrintList(head);

            // front of the linked list  
            data = 1; pos = 1;
            head = InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            "insertion of 1 at position 1: ");
            PrintList(head);

            // insetion at end of the linked list  
            data = 15; pos = 7;
            head = InsertAtSpecificPos(head, pos, data);
            Console.WriteLine("Linked list after" +
                            " insertion of 15 at position 7: ");
            PrintList(head);
        }
    }
}


