using AoC2024.Day8;
using Xunit;

namespace AoC2024.Tests.Day8;

public class Day8Tests
{
    [Theory]
    [InlineData("Day8/TestInput_a.txt",14)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day8/TestInput_a.txt",34)]
    [InlineData("Day8/TestInput_b.txt",9)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}