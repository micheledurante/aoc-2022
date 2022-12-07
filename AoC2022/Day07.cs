using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2022
{
    class Day07
    {
        public (int, int) Run(string[] input)
        {
            var dirs = new Dictionary<string, int>();
            var cd = new List<string>();

            for (var i = 0; i < input.Length; i++)
            {
                if (!input[i].StartsWith("$ cd"))
                {
                    continue;
                }

                if (input[i] == "$ cd ..") // back
                {
                    cd.RemoveAt(cd.Count() - 1);
                    continue;
                }

                // fwd

                cd.Add(input[i].Replace("$ cd ", ""));

                if (!dirs.ContainsKey(input[i].Replace("$ cd ", "")))
                {
                    dirs.Add(string.Join("/", cd.ToArray()), 0);
                }
                else
                {
                    continue;
                }

                var x = i + 2; // skip $ ls

                while (true)
                {
                    if (x >= input.Length || input[x].StartsWith("$ cd"))
                    {
                        break;
                    }

                    if (!input[x].StartsWith("dir "))
                    {
                        for (var y = cd.Count() - 1; y >= 0; y--)
                        {
                            dirs[string.Join("/", cd.GetRange(0, y + 1).ToArray())] += int.Parse(input[x].Split(" ")[0]);
                        }
                    }

                    x++;
                }
            }

            return (
                dirs.Values.Where(x => x <= 1e5).Sum(),
                dirs.OrderBy(x => x.Value).Where(x => x.Value >= 3e7 - (7e7 - dirs.First().Value)).First().Value
            );
        }
    }
}
