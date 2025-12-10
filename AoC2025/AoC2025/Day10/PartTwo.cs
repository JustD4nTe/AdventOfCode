using AoC.Shared;
using Microsoft.Z3;
using System.Runtime.InteropServices;

namespace AoC2025.Day10;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var raw = File.ReadAllLines(Input)
            .Select(x => x.Split(" ").ToArray())
            .ToArray();

        var result = 0;

        using var ctx = new Context();

        for (var i = 0; i < raw.Length; i++)
        {
            var joltage = raw[i][^1][1..^1].Split(",")
                                           .Select(int.Parse)
                                           .ToArray();

            var buttons = raw[i][1..^1].Select(x => x[1..^1].Split(",").Select(int.Parse)).ToArray();

            using var opt = ctx.MkOptimize();

            var buttonXs = new IntExpr[buttons.Length];

            for (var n = 0; n < buttons.Length; n++)
            {
                // create variable x_n per n's button's group 
                buttonXs[n] = ctx.MkIntConst($"x_{n}");

                // create axiom => x_n >= 0
                opt.Add(ctx.MkGe(buttonXs[n], ctx.MkInt(0)));
            }

            // create system of equations
            for (var joltageIndex = 0; joltageIndex < joltage.Length; joltageIndex++)
            {
                var equation = new List<ArithExpr>();

                // set x_n for each existing value in button
                for (var n = 0; n < buttons.Length; n++)
                {
                    if (buttons[n].Contains(joltageIndex))
                        equation.Add(buttonXs[n]);
                }

                // right equation side 
                var sumExpr = ctx.MkAdd([.. equation]);

                // result of equation => single joltage value
                var resExpr = ctx.MkInt(joltage[joltageIndex]);

                opt.Add(ctx.MkEq(sumExpr, resExpr));
            }

            opt.MkMinimize(ctx.MkAdd([.. buttonXs.Cast<ArithExpr>()]));

            var status = opt.Check();
            if (status != Status.SATISFIABLE)
            {
                throw new Exception($"Z3 could not find solution [status: {status}].");
            }
            
            for (var n = 0; n < buttonXs.Length; n++)
            {
                result += ((IntNum)opt.Model.Evaluate(buttonXs[n])).Int;
            }
        }


        return result;
    }
}