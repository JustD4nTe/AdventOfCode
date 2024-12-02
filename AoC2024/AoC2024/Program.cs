using AoC.Shared;

Solution[] solutions =
[
    new AoC2024.Day1.PartOne("Day1/input.txt"),
    new AoC2024.Day1.PartTwo("Day1/input.txt"),
    new AoC2024.Day2.PartOne("Day2/input.txt"),
    new AoC2024.Day2.PartTwo("Day2/input.txt"),
];

foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}