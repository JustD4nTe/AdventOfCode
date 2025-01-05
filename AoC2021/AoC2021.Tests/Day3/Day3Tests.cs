using AoC2021.Day3;
using Xunit;

namespace AoC2021.Tests.Day3;

public class Day3Tests
{
    [Theory]
    [InlineData("Day3/TestInput_a.txt",198)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day3/TestInput_a.txt",230)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}