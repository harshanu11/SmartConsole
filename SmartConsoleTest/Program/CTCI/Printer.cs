using System.Diagnostics;
using System;

namespace CTCINs
{
    public class Printer
    {

        public static void print(object o)
        {
            Debug.Write(o);
        }

        public static void println()
        {
            print(lineSeparator());
        }

        public static void println(object o)
        {
            print(o);
            println();
        }

        public static void printf(string s, params object[] args)
        {
            print(s);
        }

        public static void printfln(string s, params object[] args)
        {
            println(s);
        }

        public static void printArray(int[] a)
        {
            if (a == null)
            {
                print(null);
            }
            else
            {
                foreach (int n in a)
                {
                    print(n + " ");
                }
            }
            println();
        }

        public static void printArray(char[] a)
        {
            if (a == null)
            {
                print(null);
            }
            else
            {
                foreach (char n in a)
                {
                    print(n + " ");
                }
            }
            println();
        }

        public static void printArray(string[] a)
        {
            if (a == null)
            {
                print(null);
            }
            else
            {
                foreach (string n in a)
                {
                    print(n + " ");
                }
            }
            println();
        }

        public static void printArray(int[][] a)
        {
            foreach (int[] row in a)
            {
                foreach (int col in row)
                {
                    print(col + " ");
                }
                println();
            }
        }

        private static string lineSeparator()
        {
            return Environment.NewLine;
        }
    }
}
