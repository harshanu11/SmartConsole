using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DSA450
{
    public class Greedy450 
    {
        #region Activity Selection Problem
        public static void printMaxActivities(int[] s,
                                    int[] f, int n)
        {
            int i, j;

            Console.Write("Following activities are selected : ");

            // The first activity always gets selected
            i = 0;
            Console.Write(i + " ");

            // Consider rest of the activities
            for (j = 1; j < n; j++)
            {
                // If this activity has start time greater than or
                // equal to the finish time of previously selected
                // activity, then select it
                if (s[j] >= f[i])
                {
                    Console.Write(j + " ");
                    i = j;
                }
            }
        }

        [Fact]
        public void printMaxActivitiesTest()
        {
            int[] s = { 1, 3, 0, 5, 8, 5 };
            int[] f = { 2, 4, 6, 7, 9, 9 };
            int n = s.Length;

            printMaxActivities(s, f, n);
        }
        #endregion
        #region Job SequencingProblem
        class GFG : IComparer<Job>
        {
            public int Compare(Job x, Job y)
            {
                if (x.profit == 0 || y.profit == 0)
                {
                    return 0;
                }

                // CompareTo() method
                return (y.profit).CompareTo(x.profit);

            }
        }


        public class Job
        {

            // Each job has a unique-id,
            // profit and deadline
            char id;
            public int deadline, profit;

            // Constructors
            public Job() { }

            public Job(char id, int deadline, int profit)
            {
                this.id = id;
                this.deadline = deadline;
                this.profit = profit;
            }

            // Function to schedule the jobs take 2
            // arguments arraylist and no of jobs to schedule
            void printJobScheduling(List<Job> arr, int t)
            {
                // Length of array
                int n = arr.Count;

                GFG gg = new GFG();
                // Sort all jobs according to
                // decreasing order of profit
                arr.Sort(gg);

                // To keep track of free time slots
                bool[] result = new bool[t];

                // To store result (Sequence of jobs)
                char[] job = new char[t];

                // Iterate through all given jobs
                for (int i = 0; i < n; i++)
                {
                    // Find a free slot for this job
                    // (Note that we start from the
                    // last possible slot)
                    for (int j
                        = Math.Min(t - 1, arr[i].deadline - 1);
                        j >= 0; j--)
                    {

                        // Free slot found
                        if (result[j] == false)
                        {
                            result[j] = true;
                            job[j] = arr[i].id;
                            break;
                        }
                    }
                }

                // Print the sequence
                foreach (char jb in job)
                {
                    Console.Write(jb + " ");
                }
                Debug.WriteLine();
            }

            [Fact]
            static public void SequencingProblemTest()
            {

                List<Job> arr = new List<Job>();

                arr.Add(new Job('a', 2, 100));
                arr.Add(new Job('b', 1, 19));
                arr.Add(new Job('c', 2, 27));
                arr.Add(new Job('d', 1, 25));
                arr.Add(new Job('e', 3, 15));

                // Function call
                Debug.WriteLine("Following is maximum "
                                + "profit sequence of jobs");

                Job job = new Job();

                // Calling function
                job.printJobScheduling(arr, 3);

            }
        }
        #endregion
        #region Huffman Coding
        //checked utube


        #endregion
        #region Water Connection Problem
        // number of houses and number
        // of pipes
        static int n, p;

        static int[] rd = new int[1100];

        static int[] wt = new int[1100];

        static int[] cd = new int[1100];

        static List<int> a =
                new List<int>();

        static List<int> b =
                new List<int>();

        static List<int> c =
                new List<int>();

        static int ans;

        static int dfs(int w)
        {
            if (cd[w] == 0)
                return w;
            if (wt[w] < ans)
                ans = wt[w];

            return dfs(cd[w]);
        }

        // Function to perform calculations.
        static void solve(int[,] arr)
        {
            int i = 0;

            while (i < p)
            {

                int q = arr[i, 0];
                int h = arr[i, 1];
                int t = arr[i, 2];

                cd[q] = h;
                wt[q] = t;
                rd[h] = q;
                i++;
            }

            a = new List<int>();
            b = new List<int>();
            c = new List<int>();

            for (int j = 1; j <= n; ++j)

                /*If a pipe has no ending vertex
                but has starting vertex i.e is
                an outgoing pipe then we need
                to start DFS with this vertex.*/
                if (rd[j] == 0 && cd[j] > 0)
                {
                    ans = 1000000000;
                    int w = dfs(j);

                    // We put the details of
                    // component in final output
                    // array
                    a.Add(j);
                    b.Add(w);
                    c.Add(ans);
                }

            Debug.WriteLine(a.Count);

            for (int j = 0; j < a.Count; ++j)
                Debug.WriteLine(a[j] + " "
                    + b[j] + " " + c[j]);
        }

        [Fact]
        public void WaterConnectionProblem()
        {
            n = 9;
            p = 6;

            // set the value of the araray
            // to zero
            for (int i = 0; i < 1100; i++)
                rd[i] = cd[i] = wt[i] = 0;

            int[,] arr = { { 7, 4, 98 },
                        { 5, 9, 72 },
                        { 4, 6, 10 },
                        { 2, 8, 22 },
                        { 9, 7, 17 },
                        { 3, 1, 66 } };
            solve(arr);
        }
        #endregion
        #region Fractional Knapsack Problem
        class item
        {
            public int value;
            public int weight;

            public item(int value, int weight)
            {
                this.value = value;
                this.weight = weight;
            }
        }

        class cprCompare : IComparer
        {
            public int Compare(Object x, Object y)
            {
                item item1 = (item)x;
                item item2 = (item)y;
                double cpr1 = (double)item1.value /
                            (double)item1.weight;
                double cpr2 = (double)item2.value /
                            (double)item2.weight;

                if (cpr1 < cpr2)
                    return 1;

                return cpr1 > cpr2 ? -1 : 0;
            }
        }

        // Main greedy function to solve problem
        static double FracKnapSack(item[] items, int w)
        {

            // Sort items based on cost per units
            cprCompare cmp = new cprCompare();
            Array.Sort(items, cmp);


            // Traverse items, if it can fit,
            // take it all, else take fraction
            double totalVal = 0f;
            int currW = 0;

            foreach (item i in items)
            {
                float remaining = w - currW;

                // If the whole item can be
                // taken, take it
                if (i.weight <= remaining)
                {
                    totalVal += (double)i.value;
                    currW += i.weight;
                }

                // dd fraction untill we run out of space
                else
                {
                    if (remaining == 0)
                        break;

                    double fraction = remaining / (double)i.weight;
                    totalVal += fraction * (double)i.value;
                    currW += (int)(fraction * (double)i.weight);
                }
            }
            return totalVal;
        }

        [Fact]
        static void FracKnapSackJobTest()
        {
            item[] arr = { new item(60, 10),
                new item(100, 20),
                new item(120, 30) };

            Debug.WriteLine("Maximum value we can obtain = " +
                                FracKnapSack(arr, 50));
        }
        #endregion
    }
}
