using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022
{
    class Day03
    {
        public static (int, int) Run(string[] input)
        {
            var part1 = 0;
            var part2 = 0;
            var p = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            for (var x = 0; x < input.Length; x++)
            {
                var l = new HashSet<char>(input[x].Substring(0, input[x].Length / 2));
                var r = new HashSet<char>(input[x].Substring(input[x].Length / 2));
                l.IntersectWith(r);
                part1 += Array.IndexOf(p, l.First());
            }

            for (var i = 0; i < input.Length; i += 3)
            {
                var elem = input.Skip(i).Take(3).ToList();

                var s1 = new HashSet<char>(elem[0]);
                var s2 = new HashSet<char>(elem[1]);
                var s3 = new HashSet<char>(elem[2]);

                s1.IntersectWith(s2);
                s1.IntersectWith(s3);
                part2 += Array.IndexOf(p, s1.First());
            }

            return (part1, part2);
        }
    }
}
