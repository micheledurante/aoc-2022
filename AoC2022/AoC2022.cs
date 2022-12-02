using System;
using System.IO;

namespace AoC2022
{
    class AoC2022
    {
        private static string[] ReadInput(string name)
        {
            return File.ReadAllLines(@".\Data\" + name);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Day 1: " + Day01.Run(ReadInput("day01.txt")));
            Console.WriteLine("Day 2: " + Day02.Run(ReadInput("day02.txt")));
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
