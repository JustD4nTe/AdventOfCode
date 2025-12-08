using AoC2025.Day8;

namespace AoC2025.Tests.Day8;

public class Day8Tests
{
    [Theory]
    [InlineData("Day8/TestInput_a.txt", 40)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 10).Solve());
    }

    [Theory]
    [InlineData("Day8/TestInput_a.txt", 25272)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}