using System.Diagnostics;
using AoC.Shared;

Solution[] solutions =
[
    new AoC2025.Day1.PartOne("Day1/input.txt"),
    new AoC2025.Day1.PartTwo("Day1/input.txt"),
    new AoC2025.Day2.PartOne("Day2/input.txt"),
    new AoC2025.Day2.PartTwo("Day2/input.txt"),
    new AoC2025.Day3.PartOne("Day3/input.txt"),
    new AoC2025.Day3.PartTwo("Day3/input.txt"),
    new AoC2025.Day4.PartOne("Day4/input.txt"),
    new AoC2025.Day4.PartTwo("Day4/input.txt"),
    new AoC2025.Day5.PartOne("Day5/input.txt", 192),
    new AoC2025.Day5.PartTwo("Day5/input.txt", 192),
    new AoC2025.Day6.PartOne("Day6/input.txt"),
    new AoC2025.Day6.PartTwo("Day6/input.txt"),
    new AoC2025.Day7.PartOne("Day7/input.txt"),
    new AoC2025.Day7.PartTwo("Day7/input.txt"),
    new AoC2025.Day8.PartOne("Day8/input.txt", 1000),
    new AoC2025.Day8.PartTwo("Day8/input.txt"),
    //new AoC2025.Day9.PartOne("Day9/input.txt"),
    //new AoC2025.Day9.PartTwo("Day9/input.txt"),
    //new AoC2025.Day10.PartOne("Day10/input.txt"),
    //new AoC2025.Day10.PartTwo("Day10/input.txt"),
    //new AoC2025.Day11.PartOne("Day11/input.txt"),
    //new AoC2025.Day11.PartTwo("Day11/input.txt"),
    //new AoC2025.Day12.PartOne("Day12/input.txt"),
    //new AoC2025.Day12.PartTwo("Day12/input.txt"),
    //new AoC2025.Day13.PartOne("Day13/input.txt"),
    //new AoC2025.Day13.PartTwo("Day13/input.txt"),
    //new AoC2025.Day14.PartOne("Day14/input.txt"),
    //new AoC2025.Day14.PartTwo("Day14/input.txt"),
    //new AoC2025.Day15.PartOne("Day15/input.txt"),
    //new AoC2025.Day15.PartTwo("Day15/input.txt"),
    //new AoC2025.Day16.PartOne("Day16/input.txt"),
    //new AoC2025.Day16.PartTwo("Day16/input.txt"),
    //new AoC2025.Day17.PartOne("Day17/input.txt"),
    //new AoC2025.Day17.PartTwo("Day17/input.txt"),
    //new AoC2025.Day18.PartOne("Day18/input.txt"),
    //new AoC2025.Day18.PartTwo("Day18/input.txt"),
    //new AoC2025.Day19.PartOne("Day19/input.txt"),
    //new AoC2025.Day19.PartTwo("Day19/input.txt"),
    //new AoC2025.Day20.PartOne("Day20/input.txt"),
    //new AoC2025.Day20.PartTwo("Day20/input.txt"),
    //new AoC2025.Day21.PartOne("Day21/input.txt"),
    //new AoC2025.Day21.PartTwo("Day21/input.txt"),
    //new AoC2025.Day22.PartOne("Day22/input.txt"),
    //new AoC2025.Day22.PartTwo("Day22/input.txt"),
    //new AoC2025.Day23.PartOne("Day23/input.txt"),
    //new AoC2025.Day23.PartTwo("Day23/input.txt"),
    //new AoC2025.Day24.PartOne("Day24/input.txt"),
    //new AoC2025.Day24.PartTwo("Day24/input.txt"),
    //new AoC2025.Day25.PartOne("Day25/input.txt"),
];

var sw = new Stopwatch();
sw.Start();
foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}

sw.Stop();
Console.WriteLine(sw.Elapsed);