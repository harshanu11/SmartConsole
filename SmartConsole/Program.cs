using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            int[] price1 = new int[] { 1, 2, 3, 4, 5, 6 };
            Queue<int> q = new Queue<int>();

            for (int p = 0; p < price1.Length; p++)
            {
                if (q.Count > 0)
                {
                    if (q.Peek() < price1[p])
                    {

                    }
                }
                q.Enqueue(price1[p]);
            }
        }

    }

}
