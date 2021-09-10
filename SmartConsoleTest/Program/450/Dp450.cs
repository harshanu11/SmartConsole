using System.Diagnostics;
using System;
using Xunit;

namespace DSA450
{
    public class Dp450 
    {
        #region Coin ChangeProblem
        public virtual long count(int[] S, int m, int n)
        {
            long[] table = new long[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                table[i] = 0;
            }
            table[0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = S[i]; j <= n; j++)
                {
                    table[j] += table[j - S[i]];
                }
            }

            return table[n];

        }

        #endregion
        #region Knapsack Problem

        static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        // Returns the maximum value that
        // can be put in a knapsack of
        // capacity W
        static int knapSack(int W, int[] wt,
                            int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom
            // up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;

                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(
                            val[i - 1]
                            + K[i - 1, w - wt[i - 1]],
                            K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[n, W];
        }

        [Fact]
        static void KnapsackTestDp()
        {
            int[] val = new int[] { 60, 100, 120 };
            int[] wt = new int[] { 10, 20, 30 };
            int W = 50;
            int n = val.Length;

            Debug.WriteLine(knapSack(W, wt, val, n));
        }
        #endregion
        #region Binomial CoefficientProblem
        // Returns value of Binomial
        // Coefficient C(n, k)
        static int binomialCoeff(int n, int k)
        {

            // Base Cases
            if (k > n)
                return 0;
            if (k == 0 || k == n)
                return 1;

            // Recur
            return binomialCoeff(n - 1, k - 1)
                + binomialCoeff(n - 1, k);
        }

        [Fact]
        public void binomialCoeffTest()
        {
            int n = 5, k = 2;
            Console.Write("Value of C(" + n + "," + k + ") is "
                        + binomialCoeff(n, k));
        }
        #endregion
        #region Permutation CoefficientProblem
        static int permutationCoeff(int n,
                                int k)
        {
            int[,] P = new int[n + 2, k + 2];

            // Calculate value of Permutation
            // Coefficient in bottom up manner
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0;
                    j <= Math.Min(i, k);
                    j++)
                {
                    // Base Cases
                    if (j == 0)
                        P[i, j] = 1;

                    // Calculate value using previosly
                    // stored values
                    else
                        P[i, j] = P[i - 1, j] +
                                (j * P[i - 1, j - 1]);

                    // This step is important
                    // as P(i,j)=0 for j>i
                    P[i, j + 1] = 0;
                }
            }
            return P[n, k];
        }

        [Fact]
        public void permutationCoeffTest()
        {
            int n = 10, k = 2;
            Debug.WriteLine("Value of P( " + n +
                            "," + k + ")" + " is " +
                            permutationCoeff(n, k));
        }
        #endregion
        #region Program for nth Catalan Number
        // A recursive function to find
        // nth catalan number
        static int catalan(int n)
        {
            int res = 0;

            // Base case
            if (n <= 1)
            {
                return 1;
            }
            for (int i = 0; i < n; i++)
            {
                res += catalan(i)
                    * catalan(n - i - 1);
            }
            return res;
        }

        [Fact]
        public void catalanTest()
        {
            for (int i = 0; i < 10; i++)
                Console.Write(catalan(i) + " ");
        }
        #endregion
    }
}
