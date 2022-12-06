using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2022
{
    class Day05
    {
        public (string, string) Run(string[] input)
        {
            var stacks_1 = new List<char>[9].Select(x => new List<char>()).ToArray();
            var stacks_2 = new List<char>[9].Select(x => new List<char>()).ToArray();
            var ops = new string[input.Length - 10];

            foreach (var line in input.Take(8).ToArray())
            {
                var stack_i = -1;

                for (var i = 0; i < line.Length; i += 4)
                {
                    stack_i++;

                    if (line[i + 1] != 0)
                    {
                        var item = char.Parse(line[i + 1].ToString());

                        if (item != 32)
                        {
                            stacks_1[stack_i].Add(item);
                            stacks_2[stack_i].Add(item);
                        }
                    }
                }
            }

            for (var i = 10; i < input.Length; i++)
            {
                var line = input[i];
                var op = Regex.Matches(input[i], @"move ([0-9]+) from ([0-9]+) to ([0-9]+)")
                    .OfType<Match>()
                    .Select(l => l.Groups)
                    .ToList().First();
                var n = int.Parse(op[1].Value);
                var s = int.Parse(op[2].Value) - 1;
                var d = int.Parse(op[3].Value) - 1;

                stacks_1[d].InsertRange(0, stacks_1[s].Take(n).Reverse().ToList());
                stacks_1[s].RemoveRange(0, n);
            }

            for (var i = 10; i < input.Length; i++)
            {
                var line = input[i];
                var op = Regex.Matches(input[i], @"move ([0-9]+) from ([0-9]+) to ([0-9]+)")
                    .OfType<Match>()
                    .Select(l => l.Groups)
                    .ToList().First();
                var n = int.Parse(op[1].Value);
                var s = int.Parse(op[2].Value) - 1;
                var d = int.Parse(op[3].Value) - 1;

                stacks_2[d].InsertRange(0, stacks_2[s].Take(n).ToList());
                stacks_2[s].RemoveRange(0, n);
            }

            return (
                string.Join("", stacks_1.Select(x => x.First().ToString()).ToArray()),
                string.Join("", stacks_2.Select(x => x.First().ToString()).ToArray())
                );
        }
    }
}
