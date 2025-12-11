using AoC2025.Day11;

namespace AoC2025.Tests.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData("Day11/TestInput_a.txt", 5)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day11/TestInput_b.txt", 2)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}