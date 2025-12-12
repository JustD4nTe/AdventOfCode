using System.Diagnostics;
using AoC.Shared;

Solution[] solutions =
[
    new AoC2025.Day01.PartOne("Day01/input.txt"),
    new AoC2025.Day01.PartTwo("Day01/input.txt"),
    new AoC2025.Day02.PartOne("Day02/input.txt"),
    new AoC2025.Day02.PartTwo("Day02/input.txt"),
    new AoC2025.Day03.PartOne("Day03/input.txt"),
    new AoC2025.Day03.PartTwo("Day03/input.txt"),
    new AoC2025.Day04.PartOne("Day04/input.txt"),
    new AoC2025.Day04.PartTwo("Day04/input.txt"),
    new AoC2025.Day05.PartOne("Day05/input.txt", 192),
    new AoC2025.Day05.PartTwo("Day05/input.txt", 192),
    new AoC2025.Day06.PartOne("Day06/input.txt"),
    new AoC2025.Day06.PartTwo("Day06/input.txt"),
    new AoC2025.Day07.PartOne("Day07/input.txt"),
    new AoC2025.Day07.PartTwo("Day07/input.txt"),
    new AoC2025.Day08.PartOne("Day08/input.txt", 1000),
    new AoC2025.Day08.PartTwo("Day08/input.txt"),
    new AoC2025.Day09.PartOne("Day09/input.txt"),
    new AoC2025.Day09.PartTwo("Day09/input.txt"),
    new AoC2025.Day10.PartOne("Day10/input.txt"),
    new AoC2025.Day10.PartTwo("Day10/input.txt"),
    new AoC2025.Day11.PartOne("Day11/input.txt"),
    new AoC2025.Day11.PartTwo("Day11/input.txt"),
    new AoC2025.Day12.PartOne("Day12/input.txt")
];

var sw = new Stopwatch();
sw.Start();
foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}

sw.Stop();
Console.WriteLine(sw.Elapsed);