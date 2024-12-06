using AoC2024.Day6;
using Xunit;

namespace AoC2024.Tests.Day6;

public class Day6Tests
{
    [Theory]
    [InlineData("Day6/TestInput_a.txt",41)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day6/TestInput_a.txt",6)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}