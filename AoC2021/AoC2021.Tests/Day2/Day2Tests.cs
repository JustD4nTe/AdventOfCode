using AoC2021.Day2;
using Xunit;

namespace AoC2021.Tests.Day2;

public class Day2Tests
{
    [Theory]
    [InlineData("Day2/TestInput_a.txt",150)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day2/TestInput_a.txt",900)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}