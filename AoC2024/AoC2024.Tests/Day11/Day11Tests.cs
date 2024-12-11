using AoC2024.Day11;
using Xunit;

namespace AoC2024.Tests.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData("Day11/TestInput_a.txt",55312)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day11/TestInput_a.txt",65601038650482)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}