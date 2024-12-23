using AoC2024.Day23;
using Xunit;

namespace AoC2024.Tests.Day23;

public class Day23Tests
{
    [Theory]
    [InlineData("Day23/TestInput_a.txt",7)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day23/TestInput_a.txt",4)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}