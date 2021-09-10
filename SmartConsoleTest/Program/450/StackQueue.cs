using System.Diagnostics;
using System;
using Xunit;

namespace DSA450
{
    public class StackQueue 
    {
        #region  Implement Stack from Scratch

        #endregion
        #region  Implement Queue from Scratch

        #endregion
        #region Implement 2 stack in an array
        //Function to push an integer into the stack1.
        //public void push1(int x, TwoStack sq)
        //{
        //    //if there is space between the top of both stacks 
        //    //we push the element at top1+1.
        //    if (sq.top1 < sq.top2 - 1)
        //    {
        //        sq.top1++;
        //        sq.arr[sq.top1] = x;
        //    }
        //}

        ////Function to push an integer into the stack2.
        //public void push2(int x, TwoStack sq)
        //{
        //    //if there is space between the top of both stacks 
        //    //we push the element at top2-1.
        //    if (sq.top1 < sq.top2 - 1)
        //    {
        //        sq.top2--;
        //        sq.arr[sq.top2] = x;
        //    }
        //}

        ////Function to remove an element from top of the stack1.
        //public int pop1(TwoStack sq)
        //{
        //    //if top1==-1, stack1 is empty so we return -1 else we 
        //    //return the top element of stack1.
        //    if (sq.top1 >= 0)
        //    {
        //        int x = sq.arr[sq.top1];
        //        sq.top1--;
        //        return x;
        //    }
        //    else
        //        return -1;
        //}

        ////Function to remove an element from top of the stack2.
        //public int pop2(TwoStack sq)
        //{
        //    //if top2==size of array, stack2 is empty so we return -1 else we 
        //    //return the top element of stack2.
        //    if (sq.top2 < sq.size)
        //    {
        //        int x = sq.arr[sq.top2];
        //        sq.top2++;
        //        return x;
        //    }
        //    else
        //        return -1;
        //}
        #endregion
        #region Implement "N" stacks in an Array
        // A c# class to represent k stacks in a single array of size n
        public class KStack
        {
            public int[] arr; // Array of size n to store actual content to be stored in stacks
            public int[] top; // Array of size k to store indexes of top elements of stacks
            public int[] next; // Array of size n to store next entry in all stacks
                               // and free list
            public int n, k;
            public int free; // To store beginning index of free list
            public KStack(int k1, int n1)
            {
                k = k1;
                n = n1;
                arr = new int[n];
                top = new int[k];
                next = new int[n];
                for (int i = 0; i < k; i++)
                {
                    top[i] = -1;
                }
                free = 0;
                for (int i = 0; i < n - 1; i++)
                {
                    next[i] = i + 1;
                }
                next[n - 1] = -1; // -1 is used to indicate end of free list
            }
            public virtual bool Full
            {
                get
                {
                    return (free == -1);
                }
            }
            public virtual void push(int item, int sn)
            {
                // Overflow check
                if (Full)
                {
                    Debug.WriteLine("Stack Overflow");
                    return;
                }

                int i = free; // Store index of first free slot
                free = next[i];
                next[i] = top[sn];
                top[sn] = i;
                arr[i] = item;
            }
            public virtual int pop(int sn)
            {
                if (isEmpty(sn))
                {
                    Debug.WriteLine("Stack Underflow");
                    return int.MaxValue;
                }
                int i = top[sn];
                top[sn] = next[i]; // Change top to store next of previous top
                next[i] = free;
                free = i;
                return arr[i];
            }
            public virtual bool isEmpty(int sn)
            {
                return (top[sn] == -1);
            }

        }

        [Fact]
        public static void ImplementNStackTest()
        {
            int k = 3, n = 10;
            KStack ks = new KStack(k, n);
            ks.push(15, 2);
            ks.push(45, 2);
            ks.push(17, 1);
            ks.push(49, 1);
            ks.push(39, 1);
            ks.push(11, 0);
            ks.push(9, 0);
            ks.push(7, 0);
            Debug.WriteLine("Popped element from stack 2 is " + ks.pop(2));
            Debug.WriteLine("Popped element from stack 1 is " + ks.pop(1));
            Debug.WriteLine("Popped element from stack 0 is " + ks.pop(0));
        }
        #endregion
        #region find the middle element of a stack
        public class DLLNode
        {
            public DLLNode prev;
            public int data;
            public DLLNode next;
            public DLLNode(int d) { data = d; }
        }
        public class myStack
        {
            public DLLNode head;
            public DLLNode mid;
            public int count;
        }

        myStack createMyStack()
        {
            myStack ms = new myStack();
            ms.count = 0;
            return ms;
        }
        void push(myStack ms, int new_data)
        {
            DLLNode new_DLLNode = new DLLNode(new_data);
            new_DLLNode.prev = null;
            new_DLLNode.next = ms.head;
            ms.count += 1;
            if (ms.count == 1)
            {
                ms.mid = new_DLLNode;
            }
            else
            {
                ms.head.prev = new_DLLNode;
                if ((ms.count % 2) != 0)
                    ms.mid = ms.mid.prev;
            }
            ms.head = new_DLLNode;
        }

        int pop(myStack ms)
        {
            if (ms.count == 0)
            {
                Debug.WriteLine("Stack is empty");
                return -1;
            }
            DLLNode head = ms.head;
            int item = head.data;
            ms.head = head.next;
            if (ms.head != null)
                ms.head.prev = null;
            ms.count -= 1;
            if (ms.count % 2 == 0)
                ms.mid = ms.mid.next;
            return item;
        }

        int findMiddle(myStack ms)
        {
            if (ms.count == 0)
            {
                Debug.WriteLine("Stack is empty now");
                return -1;
            }
            return ms.mid.data;
        }

        [Fact]
        public void FindMiddleElementStack()
        {
            myStack ms = createMyStack();
            push(ms, 11);
            push(ms, 22);
            push(ms, 33);
            push(ms, 44);
            push(ms, 55);
            push(ms, 66);
            push(ms, 77);

            Debug.WriteLine("Item popped is " + pop(ms));
            Debug.WriteLine("Item popped is " + pop(ms));
            Debug.WriteLine("Middle Element is " + findMiddle(ms));
        }
        #endregion
    }
}
