using AoC2021.Day7;
using Xunit;

namespace AoC2021.Tests.Day7;

public class Day7Tests
{
    [Theory]
    [InlineData("Day7/TestInput_a.txt",37)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day7/TestInput_a.txt",168)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}