using AoC2024.Day19;
using Xunit;

namespace AoC2024.Tests.Day19;

public class Day19Tests
{
    [Theory]
    [InlineData("Day19/TestInput_a.txt",6)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day19/TestInput_a.txt",16)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}