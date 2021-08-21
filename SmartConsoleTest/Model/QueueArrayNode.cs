namespace CollectionTest
{
    public class QueueArrayNode
    {
        public static int front, rear, capacity;
        private static int[] queue;

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

                rear--;
            }
            return;
        }

        // print queue elements

        // print front of queue
        public void queueFront()
        {
            if (front == rear)
            {
                return;
            }
            return;
        }
    }
}
