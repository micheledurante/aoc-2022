using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022
{
    class Day04
    {
        public static (int, int) Run(string[] input)
        {
            var part1 = 0;
            var part2 = 0;
            var pairs = input.Select(y => y.Split(","))
                .Select(x => x.Select(z => z.Split("-")
                .Select(a => int.Parse(a)).ToArray()).ToArray())
                .ToArray();

            foreach (var pair in pairs) // 1-93,2-11
            {
                if ((pair[1][0] >= pair[0][0] && pair[1][1] <= pair[0][1]) || (pair[0][0] >= pair[1][0] && pair[0][1] <= pair[1][1]))
                {
                    part1++;
                }

                if (pair[1][0] > pair[0][1] || pair[1][1] < pair[0][0])
                {
                    part2++;
                }
            }

            return (part1, input.Length - part2);
        }
    }
}
