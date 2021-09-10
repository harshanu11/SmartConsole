using System.Diagnostics;
using System;
using System.Collections;
using Xunit;

namespace CollectionTest
{
    public class QueueTest
    {
        [Fact]
        public void BasicTest(){
            Queue q = new Queue();
        }
        [Fact]
        public void MyQueueWithStackTest()
        {
            QueueStackNode q = new QueueStackNode();
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
            QueueLLNode q = new QueueLLNode();
            q.enqueue(10);
            q.enqueue(20);
            q.dequeue();
            q.dequeue();
            q.enqueue(30);
            q.enqueue(40);
            q.enqueue(50);
            q.dequeue();
            Debug.WriteLine("Queue Front : " + q.front.key);
            Debug.WriteLine("Queue Rear : " + q.rear.key);

        }

        [Fact]
        public void QueueUsingArrayTest()
        {
            QueueArrayNode q = new QueueArrayNode(20);
            q.queueEnqueue(10);
            var peek = q.Peek1();
            q.queueEnqueue(20);
            q.queueDequeue();
            q.queueDequeue();
            q.queueEnqueue(30);
            q.queueEnqueue(40);
            q.queueEnqueue(50);
            q.queueDequeue();
            Debug.WriteLine("Queue Front : " + QueueArrayNode.front);
            Debug.WriteLine("Queue Rear : " + QueueArrayNode.rear);

        }
    }
}
