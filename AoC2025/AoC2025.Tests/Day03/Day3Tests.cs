using AoC2025.Day03;

namespace AoC2025.Tests.Day03;

public class Day3Tests
{
    [Theory]
    [InlineData("Day03/TestInput_a.txt", 357)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day03/TestInput_a.txt", 3121910778619)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}