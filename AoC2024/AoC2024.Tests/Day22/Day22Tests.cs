using AoC2024.Day22;
using Xunit;

namespace AoC2024.Tests.Day22;

public class Day22Tests
{
    [Theory]
    [InlineData("Day22/TestInput_a.txt",37327623)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day22/TestInput_b.txt",23)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}