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
            Console.WriteLine("Day 1: " + new Day01().Run(ReadInput("day01.txt")));
            Console.WriteLine("Day 2: " + new Day02().Run(ReadInput("day02.txt")));
            Console.WriteLine("Day 3: " + new Day03().Run(ReadInput("day03.txt")));
            Console.WriteLine("Day 4: " + new Day04().Run(ReadInput("day04.txt")));
            Console.WriteLine("Day 5: " + new Day05().Run(ReadInput("day05.txt")));
            Console.WriteLine("Day 6: " + new Day06().Run(ReadInput("day06.txt")));
            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
    }
}
