namespace CollectionTest
{
    public class QueueArrayNode
    {
        public static int front, rear, capacity;
        public static int[] queue;
        public int Length = 0;
        public QueueArrayNode(int c)
        {
            front = rear = 0;
            capacity = c;
            queue = new int[capacity];
        }

        // function to insert an element
        // at the rear of the queue
        public void queueEnqueue(int data)
        {
            if (capacity == rear)
            {
                return;
            }
            else
            {
                queue[rear] = data;
                rear++;
                Length++;
            }
            return;
        }
        public void queueDequeue()
        {
            if (front == rear)
            {
                return;
            }
            else
            {
                for (int i = 0; i < rear - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                if (rear < capacity)
                    queue[rear] = 0;
                Length--;
                rear--;
            }
            return;
        }

        // print queue elements

        // print front of queue
        public int Peek1()
        {
            if (front == rear)
            {
                return 0;
            }
            return queue[front];
        }
        public int Peek2()
        {
            if (front == rear || Length < 3)
            {
                return 0;
            }
            return queue[front+1];
        }
        public int Peek3()
        {
            if (front == rear || Length < 3)
            {
                return 0;
            }
            return queue[front+2];
        }
    }
}
