using AoC2025.Day7;

namespace AoC2025.Tests.Day7;

public class Day7Tests
{
    [Theory]
    [InlineData("Day7/TestInput_a.txt", 21)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day7/TestInput_a.txt", 40)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}