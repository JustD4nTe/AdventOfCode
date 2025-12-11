using AoC2025.Day07;

namespace AoC2025.Tests.Day07;

public class Day7Tests
{
    [Theory]
    [InlineData("Day07/TestInput_a.txt", 21)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day07/TestInput_a.txt", 40)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}