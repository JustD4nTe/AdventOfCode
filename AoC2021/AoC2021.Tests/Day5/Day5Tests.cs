using AoC2021.Day5;
using Xunit;

namespace AoC2021.Tests.Day5;

public class Day5Tests
{
    [Theory]
    [InlineData("Day5/TestInput_a.txt",5)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day5/TestInput_a.txt",12)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}