using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CollectionTest
{
    public class StackTest
    {
        [Fact]
        public void StackProblem()
        {
            Stack<string> bracketStack = new Stack<string>();
            if (bracketStack.Count == 0)
            {

            }
            bracketStack.Push("{");
            string pop = bracketStack.Pop();
        }
        [Fact]
        public void ThreeStackInOneFixedArrayTest()
        {


        }
        [Fact]
        public void ThreeStackInOneDynamicArrayCircularLL()
        {


        }
        [Fact]
        public void DesignStackWithBigO1Test()
        {


        }
        [Fact]
        public void StackReturnsMinimumElementWithoutUsingAuxiliarystackTest()
        {
            MyStack s = new MyStack();
            s.Push(3);
            s.Push(5);
            s.getMin();
            s.Push(2);
            s.Push(1);
            s.getMin();
            s.Pop();
            s.getMin();
            s.Pop();
            s.Peek();
        }
        [Fact]
        public void StackWtihArrayTest()
        {

            StackWtihArray p = new StackWtihArray(5);

            p.push(10);
            p.push(20);
            p.push(30);
            p.printStack();
            p.pop();
        }
        [Fact]
        public void StackWtihArrayListTest()
        {

            StackUsingArrayList myStack = new StackUsingArrayList(); // Declare a stack of maximum size 4
                                                                     // Populate the stack
            myStack.push(5);
            myStack.push(8);
            myStack.push(2);
            myStack.push(9);
        }
        [Fact]
        public void SortStackTest()
        {
            Stack<int> input = new Stack<int>();
            input.Push(34);
            input.Push(3);
            input.Push(31);
            input.Push(98);
            input.Push(92);
            input.Push(23);

            // This is the temporary stack
            Stack<int> tmpStack = sortstack(input);
            Console.WriteLine("Sorted numbers are:");

            while (tmpStack.Count > 0)
            {
                Console.Write(tmpStack.Pop() + " ");
            }

        }
        public static Stack<int> sortstack(Stack<int> input)
        {
            Stack<int> tmpStack = new Stack<int>();
            while (input.Count > 0)
            {
                // pop out the first element
                int tmp = input.Pop();

                // while temporary stack is not empty and
                // top of stack is greater than temp
                while (tmpStack.Count > 0 && tmpStack.Peek() > tmp)
                {
                    // pop from temporary stack and
                    // push it to the input stack
                    input.Push(tmpStack.Pop());
                }

                // push temp in tempory of stack
                tmpStack.Push(tmp);
            }
            return tmpStack;
        }

    }
    public class FixedMultiStack
    {
        private int numberOfStacks = 3;
        private int stackCapacity;
        private int[] values;
        private int[] sizes;
        public FixedMultiStack(int stackSize)
        {
            stackCapacity = stackSize;
            values = new int[stackSize * numberOfStacks];
            sizes = new int[numberOfStacks];
        }
        public void push(int stackNum, int value)
        {
            /* Check that we have space fo r the next element */
            if (isFull(stackNum))
            {
                throw new System.StackOverflowException();
                //ackingTheCodinglnterview.com | 6t h Edition 227 Solutions to Chapter 3 j Stacks and Queues
            }
            sizes[stackNum]++;
            values[indexOfTop(stackNum)] = value;
        }
        /* Pop item from top stack. */
        public int pop(int stackNum)
        {
            if (isEmpty(stackNum))
            {
                throw new System.Exception("Stack empty");
            }
            int topindex = indexOfTop(stackNum);
            int value = values[topindex]; // Get top 
            values[topindex] = 0; // Clear 
            sizes[stackNum]--; // Shrink 
            return value;
        }

        /* Return top element. */
        public int peek(int stackNum)
        {
            if (isEmpty(stackNum))
            {
                throw new System.Exception("Stack empty");
            }
            return values[indexOfTop(stackNum)];
        }
        public bool isEmpty(int stackNum)
        {
            return sizes[stackNum] == 0;
        }
        public bool isFull(int stackNum)
        {
            return sizes[stackNum] == stackCapacity;
        }
        /* Returns index of the top of the stack. */
        private int indexOfTop(int stackNum)
        {
            int offset = stackNum + stackCapacity;
            int size = sizes[stackNum];
            return offset + size - 1;
        }
    }
    /// <summary>
    /// Design a stack that supports getMin() in O(1) time and O(1) extra space
    /// </summary>
    public class MyStack
    {
        public Stack s;
        public int minEle;

        // Constructor
        public MyStack()
        {
            s = new Stack();
        }
        public void getMin()
        {
            if (s.Count == 0)
                Console.WriteLine("Stack is empty");
            else
                Console.WriteLine("Minimum Element in the " +
                                " stack is: " + minEle);
        }
        public void Peek()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty ");
                return;
            }
            int t = (int)s.Peek(); 
            Console.Write("Top Most Element is: ");
            if (t < minEle)
                Console.WriteLine(minEle);
            else
                Console.WriteLine(t);
        }
        public void Pop()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.Write("Top Most Element Removed: ");
            int t = (int)s.Pop();
            if (t < minEle)
            {
                Console.WriteLine(minEle);
                minEle = 2 * minEle - t;
            }

            else
                Console.WriteLine(t);
        }
        public void Push(int x)
        {
            if (s.Count == 0)
            {
                minEle = x;
                s.Push(x);
                Console.WriteLine("Number Inserted: " + x);
                return;
            }
            if (x < minEle)
            {
                s.Push(2 * x - minEle);
                minEle = x;
            }

            else
                s.Push(x);

            Console.WriteLine("Number Inserted: " + x);
        }
    }

    /// <summary>
    /// Design a stack that returns a minimum element without using an auxiliary stack
    /// </summary>
    public class MinStack
    {
        // main stack to store elements
        private Stack<int> s = new Stack<int>();

        // variable to store the minimum element
        //JAVA TO C# CONVERTER NOTE: Fields cannot have the same name as methods of the current type:
        private int min_Conflict;

        // Inserts a given element on top of the stack
        public virtual void push(int x)
        {
            if (s.Count == 0)
            {
                s.Push(x);
                min_Conflict = x;
            }
            else if (x > min_Conflict)
            {
                s.Push(x);
            }
            else
            {
                s.Push(2 * x - min_Conflict);
                min_Conflict = x;
            }
        }

        // Removes the top element from the stack and returns it
        public virtual void pop()
        {
            if (s.Count == 0)
            {
                Console.WriteLine("Stack underflow!!");
            }

            int top = s.Peek();
            if (top < min_Conflict)
            {
                min_Conflict = 2 * min_Conflict - top;
            }
            s.Pop();
        }

        // Returns the minimum element from the stack in constant time
        public virtual int min()
        {
            return min_Conflict;
        }
    }

    class StackWtihArray
    {
        private int[] ele;
        private int top;
        private int max;
        public StackWtihArray(int size)
        {
            ele = new int[size]; // Maximum size of Stack
            top = -1;
            max = size;
        }

        public void push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                ele[++top] = item;
            }
        }

        public int pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} popped from stack ", ele[top]);
                return ele[top--];
            }
        }

        public int peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            else
            {
                Console.WriteLine("{0} popped from stack ", ele[top]);
                return ele[top];
            }
        }

        public void printStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.WriteLine("{0} pushed into stack", ele[i]);
                }
            }
        }
    }
    public class StackUsingArrayList
    {
        /// <summary>
        /// ArrayList representation of the stack </summary>
        internal ArrayList stackList;

        /// <summary>
        /// Constructor
        /// </summary>
        internal StackUsingArrayList()
        {
            stackList = new ArrayList();
        }

        /// <summary>
        /// Adds value to the end of list which is the top for stack
        /// </summary>
        /// <param name="value">
        ///            value to be added </param>
        internal virtual void push(int value)
        {
            stackList.Add(value);
        }

        /// <summary>
        /// Pops last element of list which is indeed the top for Stack
        /// </summary>
        /// <returns> Element popped </returns>
        internal virtual int pop()
        {

            if (!Empty)
            { // checks for an empty Stack
                int popValue = Convert.ToInt32(stackList[stackList.Count - 1]);
                stackList.RemoveAt(stackList.Count - 1); // removes the poped element
                return popValue;
            }
            else
            {
                Console.Write("The stack is already empty  ");
                return -1;
            }
        }

        /// <summary>
        /// Checks for empty Stack
        /// </summary>
        /// <returns> true if stack is empty </returns>
        internal virtual bool Empty
        {
            get
            {
                if (stackList.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Top element of stack
        /// </summary>
        /// <returns> top element of stack </returns>
        internal virtual int peek()
        {
            return Convert.ToInt32(stackList[stackList.Count - 1]);
        }
    }

}
