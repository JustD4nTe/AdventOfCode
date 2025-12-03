using AoC2025.Day3;

namespace AoC2025.Tests.Day3;

public class Day3Tests
{
    [Theory]
    [InlineData("Day3/TestInput_a.txt", 357)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day3/TestInput_a.txt", 3121910778619)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}