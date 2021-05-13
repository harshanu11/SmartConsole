﻿using Program;
using System;
using System.Collections.Generic;

namespace SmartConsole
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("size of {0} is {1} bytes", typeof(bool), sizeof(bool));
            Console.WriteLine("size of {0} is {1} bytes", typeof(byte), sizeof(byte));
            Console.WriteLine("size of {0} is {1} bytes", typeof(char), sizeof(char));
            Console.WriteLine("size of {0} is {1} bytes", typeof(UInt32), sizeof(UInt32));
            Console.WriteLine("size of {0} is {1} bytes", typeof(ulong), sizeof(ulong));
            Console.WriteLine("size of {0} is {1} bytes", typeof(decimal), sizeof(decimal));
        }

    }
}
