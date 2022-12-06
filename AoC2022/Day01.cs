using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022
{
    class Day01
    {
        public (int, int) Run(string[] input)
        {
            var calories = new int[1000];
            var counter = 0;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i].Length == 0)
                {
                    counter++; // next Elf
                    continue;
                }

                calories[counter] += int.Parse(input[i]);
            }

            return (calories.Max(), calories.OrderByDescending(x => x).Take(3).Sum());
        }
    }
}
