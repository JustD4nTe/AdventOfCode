using AoC2021.Day11;

namespace AoC2021.Tests.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData("Day11/TestInput_a.txt",1656)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day11/TestInput_a.txt",195)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}