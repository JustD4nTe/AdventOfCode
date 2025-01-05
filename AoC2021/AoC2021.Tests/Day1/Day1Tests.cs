using AoC2021.Day1;
using Xunit;

namespace AoC2021.Tests.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData("Day1/TestInput_a.txt",7)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day1/TestInput_a.txt",5)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}