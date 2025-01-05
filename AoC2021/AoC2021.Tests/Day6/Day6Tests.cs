using AoC2021.Day6;
using Xunit;

namespace AoC2021.Tests.Day6;

public class Day6Tests
{
    [Theory]
    [InlineData("Day6/TestInput_a.txt",5934)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day6/TestInput_a.txt",26984457539)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}