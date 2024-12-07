using AoC2024.Day7;
using Xunit;

namespace AoC2024.Tests.Day7;

public class Day7Tests
{
    [Theory]
    [InlineData("Day7/TestInput_a.txt",3749)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day7/TestInput_a.txt",11387)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}