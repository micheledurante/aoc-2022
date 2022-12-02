using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// A rock
// B paper
// C scissors

// loss = 0, draw = 3, win = 6

// AY,BZ,CX

namespace AoC2022
{
    class Day02
    {
        public static (int, int) Run(string[] input)
        {
            // if draw AX,BY,CZ = 3

            // if win AY,BZ,CX = 6

            var part1 = new int[input.Length];
            var part2 = new int[input.Length];
            var p0 = new string[] { "A", "B", "C" };
            var p1 = new string[] { "X", "Y", "Z" };
            var draw = new string[] { "AX", "BY", "CZ" };
            var win = new string[] { "AY", "BZ", "CX" };
            var loose = new string[] { "AZ", "BX", "CY" };

            for (var i = 0; i < input.Length; i++)
            {
                var round = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (draw.Contains(round[0] + round[1]))
                    part1[i] = 3 + Array.IndexOf(p1, round[1]) + 1;
                else if (win.Contains(round[0] + round[1]))
                    part1[i] = 6 + Array.IndexOf(p1, round[1]) + 1;
                else
                    part1[i] = 0 + Array.IndexOf(p1, round[1]) + 1;

                if (round[1] == "X") // must loose
                {
                    foreach (var item in loose)
                    {
                        if (item[0].ToString() == round[0])
                            part2[i] = 0 + Array.IndexOf(p1, item[1].ToString()) + 1;
                    }
                }

                if (round[1] == "Y") // must draw
                {
                    foreach (var item in draw)
                    {
                        if (item[0].ToString() == round[0])
                            part2[i] = 3 + Array.IndexOf(p1, item[1].ToString()) + 1;
                    }
                }

                if (round[1] == "Z") // must draw
                {
                    foreach (var item in win)
                    {
                        if (item[0].ToString() == round[0])
                            part2[i] = 6 + Array.IndexOf(p1, item[1].ToString()) + 1;
                    }
                }
            }

            return (part1.Sum(), part2.Sum());
        }
    }
}
