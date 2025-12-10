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
    new AoC2025.Day9.PartOne("Day9/input.txt"),
    new AoC2025.Day9.PartTwo("Day9/input.txt"),
    new AoC2025.Day10.PartOne("Day10/input.txt"),
    new AoC2025.Day10.PartTwo("Day10/input.txt"),
    //new AoC2025.Day11.PartOne("Day11/input.txt"),
    //new AoC2025.Day11.PartTwo("Day11/input.txt"),
    //new AoC2025.Day12.PartOne("Day12/input.txt"),
    //new AoC2025.Day12.PartTwo("Day12/input.txt")
];

var sw = new Stopwatch();
sw.Start();
foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}

sw.Stop();
Console.WriteLine(sw.Elapsed);