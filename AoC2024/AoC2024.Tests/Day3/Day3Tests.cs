using AoC2024.Day3;
using Xunit;

namespace AoC2024.Tests.Day3;

public class Day3Tests
{
    [Theory]
    [InlineData("Day3/TestInput_a.txt",161)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day3/TestInput_b.txt",48)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}