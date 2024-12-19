using System.Diagnostics;
using AoC.Shared;

Solution[] solutions =
[
    new AoC2024.Day1.PartOne("Day1/input.txt"),
    new AoC2024.Day1.PartTwo("Day1/input.txt"),
    new AoC2024.Day2.PartOne("Day2/input.txt"),
    new AoC2024.Day2.PartTwo("Day2/input.txt"),
    new AoC2024.Day3.PartOne("Day3/input.txt"),
    new AoC2024.Day3.PartTwo("Day3/input.txt"),
    new AoC2024.Day4.PartOne("Day4/input.txt"),
    new AoC2024.Day4.PartTwo("Day4/input.txt"),
    new AoC2024.Day5.PartOne("Day5/input.txt"),
    new AoC2024.Day5.PartTwo("Day5/input.txt"),
    new AoC2024.Day6.PartOne("Day6/input.txt"),
    new AoC2024.Day6.PartTwo("Day6/input.txt"),
    new AoC2024.Day7.PartOne("Day7/input.txt"),
    // new AoC2024.Day7.PartTwo("Day7/input.txt"), // To be optimized ~7s
    new AoC2024.Day8.PartOne("Day8/input.txt"),
    new AoC2024.Day8.PartTwo("Day8/input.txt"),
    new AoC2024.Day9.PartOne("Day9/input.txt"),
    new AoC2024.Day9.PartTwo("Day9/input.txt"),
    new AoC2024.Day10.PartOne("Day10/input.txt"),
    new AoC2024.Day10.PartTwo("Day10/input.txt"),
    new AoC2024.Day11.PartOne("Day11/input.txt"),
    new AoC2024.Day11.PartTwo("Day11/input.txt"),
    new AoC2024.Day12.PartOne("Day12/input.txt"),
    new AoC2024.Day12.PartTwo("Day12/input.txt"),
    new AoC2024.Day13.PartOne("Day13/input.txt"),
    new AoC2024.Day13.PartTwo("Day13/input.txt"),
    new AoC2024.Day14.PartOne("Day14/input.txt", 101, 103),
    // new AoC2024.Day14.PartTwo("Day14/input.txt", 101, 103), // Draw 100k images
    new AoC2024.Day15.PartOne("Day15/input.txt"),
    new AoC2024.Day15.PartTwo("Day15/input.txt"),
    new AoC2024.Day16.PartOne("Day16/input.txt"),
    new AoC2024.Day16.PartTwo("Day16/input.txt"),
    new AoC2024.Day17.PartOne("Day17/input.txt"),
    // new AoC2024.Day17.PartTwo("Day17/input.txt"), // not solved :c
    new AoC2024.Day18.PartOne("Day18/input.txt", 70, 1024),
    new AoC2024.Day18.PartTwo("Day18/input.txt",70),
    new AoC2024.Day19.PartOne("Day19/input.txt"),
    new AoC2024.Day19.PartTwo("Day19/input.txt"),
];

var sw = new Stopwatch();
sw.Start();
foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}
sw.Stop();
Console.WriteLine(sw.Elapsed);