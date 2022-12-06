using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022
{
    class Day06
    {
        public (int, int) Run(string[] input)
        {
            var part1 = 0;
            var part2 = 0;

            for (var i = 3; i < input[0].Length; i++)
            {
                var set = new HashSet<char>(4);

                for (var x = 0; x < 4; x++)
                {
                    set.Add(input[0][i - x]);
                }

                if (set.Count() == 4)
                {
                    part1 = i + 1;
                    break;
                }
            }

            for (var i = 13; i < input[0].Length; i++)
            {
                var set = new HashSet<char>(4);

                for (var x = 0; x < 14; x++)
                {
                    set.Add(input[0][i - x]);
                }

                if (set.Count() == 14)
                {
                    part2 = i + 1;
                    break;
                }
            }

            return (part1, part2);
        }
    }
}
