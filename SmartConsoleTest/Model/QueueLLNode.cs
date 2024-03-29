﻿namespace CollectionTest
{
    public class QNode
    {
        public int key;
        public QNode next;

        public QNode(int key)
        {
            this.key = key;
            this.next = null;
        }
    }
    public class QueueLLNode
    {
        public QNode front, rear;

        public QueueLLNode()
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
            if (this.front == null)
                return;
            QNode temp = this.front;
            this.front = this.front.next;
            if (this.front == null)
                this.rear = null;
        }
    }
}
