using System.Diagnostics;
using System;
using System.Collections;

namespace CollectionTest
{
    public class QueueStackNode
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
                Debug.WriteLine("Q is Empty");

            }

            // Return top of s1 
            int x = (int)s1.Peek();
            s1.Pop();
            return x;
        }
    }
}
