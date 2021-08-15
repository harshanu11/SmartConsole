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
            // check queue is full or not
            if (capacity == rear)
            {
                return;
            }

            // insert element at the rear
            else
            {
                queue[rear] = data;
                rear++;
            }
            return;
        }

        // function to delete an element
        // from the front of the queue
        public void queueDequeue()
        {
            // if queue is empty
            if (front == rear)
            {
                return;
            }

            // shift all the elements from index 2 till rear
            // to the right by one
            else
            {
                for (int i = 0; i < rear - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }

                // store 0 at rear indicating there's no element
                if (rear < capacity)
                    queue[rear] = 0;

                // decrement rear
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
