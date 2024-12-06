using AoC2024.Day5;
using Xunit;

namespace AoC2024.Tests.Day5;

public class Day5Tests
{
    [Theory]
    [InlineData("Day5/TestInput_a.txt",143)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day5/TestInput_a.txt",123)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}