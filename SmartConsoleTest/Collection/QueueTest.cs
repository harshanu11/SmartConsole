using System;
using System.Collections;
using Xunit;

namespace CollectionTest
{

    public class QueueTest
    {
        [Fact]
        public void MyFirstQueueTest()
        {
            MyQueue q = new MyQueue();
            q.enQueue(1);
            q.enQueue(2);
            q.enQueue(3);
            //q.Peek()  just peek without removing obj
            //q.ToArray()
            Console.Write(q.deQueue() + " ");
            Console.Write(q.deQueue() + " ");
            Console.Write(q.deQueue());

        }
        [Fact]
        public void QueueUsingLLTest()
        {
            Queue q = new Queue();
            q.enqueue(10);
            q.enqueue(20);
            q.dequeue();
            q.dequeue();
            q.enqueue(30);
            q.enqueue(40);
            q.enqueue(50);
            q.dequeue();
            Console.WriteLine("Queue Front : " + q.front.key);
            Console.WriteLine("Queue Rear : " + q.rear.key);

        }
    }
    public class MyQueue
    {
        public Stack s1 = new Stack();
        public Stack s2 = new Stack();

        public void enQueue(int x)
        {
            // Move all elements from s1 to s2 
            while (s1.Count > 0)
            {
                s2.Push(s1.Pop());
                //s1.Pop(); 
            }

            // Push item into s1 
            s1.Push(x);

            // Push everything back to s1 
            while (s2.Count > 0)
            {
                s1.Push(s2.Pop());
                //s2.Pop(); 
            }
        }

        // Dequeue an item from the queue 
        public int deQueue()
        {
            // if first stack is empty 
            if (s1.Count == 0)
            {
                Console.WriteLine("Q is Empty");

            }

            // Return top of s1 
            int x = (int)s1.Peek();
            s1.Pop();
            return x;
        }
    };
    public class QNode
    {
        public int key;
        public QNode next;

        // constructor to create
        // a new linked list node
        public QNode(int key)
        {
            this.key = key;
            this.next = null;
        }
    }

    // A class to represent a queue The queue,
    // front stores the front node of LL and
    // rear stores the last node of LL
    public class Queue
    {
        public QNode front, rear;

        public Queue()
        {
            this.front = this.rear = null;
        }

        // Method to add an key to the queue.
        public void enqueue(int key)
        {

            // Create a new LL node
            QNode temp = new QNode(key);

            // If queue is empty, then new
            // node is front and rear both
            if (this.rear == null)
            {
                this.front = this.rear = temp;
                return;
            }

            // Add the new node at the
            // end of queue and change rear
            this.rear.next = temp;
            this.rear = temp;
        }

        // Method to remove an key from queue.
        public void dequeue()
        {
            // If queue is empty, return NULL.
            if (this.front == null)
                return;

            // Store previous front and
            // move front one node ahead
            QNode temp = this.front;
            this.front = this.front.next;

            // If front becomes NULL,
            // then change rear also as NULL
            if (this.front == null)
                this.rear = null;
        }
    }
}
