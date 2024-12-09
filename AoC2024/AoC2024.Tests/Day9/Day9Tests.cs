using AoC2024.Day9;
using Xunit;

namespace AoC2024.Tests.Day9;

public class Day9Tests
{
    [Theory]
    [InlineData("Day9/TestInput_a.txt",1928)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day9/TestInput_a.txt",2858)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}