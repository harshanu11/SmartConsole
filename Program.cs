﻿using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void MainValue(string[] args)
        {
            var p1 = new MutablePoint(1, 2);
            var p2 = p1;
            p2.Y = 200;
            Console.WriteLine($"{nameof(p1)} after {nameof(p2)} is modified: {p1}");
            Console.WriteLine($"{nameof(p2)}: {p2}");

            MutateAndDisplay(p2);
            Console.WriteLine($"{nameof(p2)} after passing to a method: {p2}");


        }
        private static void MutateAndDisplay(MutablePoint p)
        {
            p.X = 100;
            Console.WriteLine($"Point mutated in a method: {p}");
        }
        public static void Main()
        {
            var n1 = new TaggedInteger(0);
            n1.AddTag("A");
            Console.WriteLine(n1);  // output: 0 [A]

            var n2 = n1;
            n2.Number = 7;
            n2.AddTag("B");

            Console.WriteLine(n1);  // output: 0 [A, B]
            Console.WriteLine(n2);  // output: 7 [A, B]

            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44
        }


            static void InArgExample(in int number)
        {
            // Uncomment the following line to see error CS8331
            number = 19;
        }
    }
    public struct MutablePoint
    {
        public int X;
        public int Y;

        public MutablePoint(int x, int y) => (X, Y) = (x, y);

        public override string ToString() => $"({X}, {Y})";
    }

    public struct TaggedInteger
    {
        public int Number;
        private List<string> tags;

        public TaggedInteger(int n)
        {
            Number = n;
            tags = new List<string>();
        }

        public void AddTag(string tag) => tags.Add(tag);

        public override string ToString() => $"{Number} [{string.Join(", ", tags)}]";
    }


}
