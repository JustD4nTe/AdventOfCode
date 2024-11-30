using AoC.Shared;

Solution[] solutions =
[
    new AoC2023.Day1.PartOne("Day1/input.txt"),
    new AoC2023.Day1.PartTwo("Day1/input.txt"),
    new AoC2023.Day2.PartOne("Day2/input.txt"),
    new AoC2023.Day2.PartTwo("Day2/input.txt"),
    new AoC2023.Day3.PartOne("Day3/input.txt"),
    new AoC2023.Day3.PartTwo("Day3/input.txt"),
    new AoC2023.Day4.PartOne("Day4/input.txt"),
    new AoC2023.Day4.PartTwo("Day4/input.txt"),
    new AoC2023.Day5.PartOne("Day5/input.txt"),
    // new AoC2023.Day5.PartTwo("Day5/input.txt"), // TODO: Optimize AoC2023.Day5.PartTwo
    new AoC2023.Day6.PartOne("Day6/input.txt"),
    new AoC2023.Day6.PartTwo("Day6/input.txt"),
    new AoC2023.Day7.PartOne("Day7/input.txt"),
    new AoC2023.Day7.PartTwo("Day7/input.txt"),
    new AoC2023.Day8.PartOne("Day8/input.txt"),
    new AoC2023.Day8.PartTwo("Day8/input.txt"),
    new AoC2023.Day9.PartOne("Day9/input.txt"),
    new AoC2023.Day9.PartTwo("Day9/input.txt"),
    new AoC2023.Day10.PartOne("Day10/input.txt"),
    new AoC2023.Day10.PartTwo("Day10/input.txt"),
    new AoC2023.Day11.PartOne("Day11/input.txt"),
    new AoC2023.Day11.PartTwo("Day11/input.txt"),
    new AoC2023.Day12.PartOne("Day12/input.txt"),
    // new AoC2023.Day12.PartTwo("Day12/input.txt"), TODO: not solved :C
    // new AoC2023.Day13.PartOne("Day13/input.txt"), TODO: not solved :C
    // new AoC2023.Day13.PartTwo("Day13/input.txt"), TODO: not solved :C
    new AoC2023.Day14.PartOne("Day14/input.txt"),
    new AoC2023.Day14.PartTwo("Day14/input.txt"),
    new AoC2023.Day15.PartOne("Day15/input.txt"),
    new AoC2023.Day15.PartTwo("Day15/input.txt"),
    new AoC2023.Day16.PartOne("Day16/input.txt"),
    new AoC2023.Day16.PartTwo("Day16/input.txt"),
    // new AoC2023.Day17.PartOne("Day17/input.txt"), TODO: not solved :C
    // new AoC2023.Day17.PartTwo("Day17/input.txt"), TODO: not solved :C
    // new AoC2023.Day18.PartOne("Day18/input.txt"), TODO: not solved :C
];

foreach (var solution in solutions)
{
    SolutionManager.BenchmarkSolution(solution);
}