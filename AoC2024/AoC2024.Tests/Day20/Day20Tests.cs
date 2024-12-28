using AoC2024.Day20;
using Xunit;

namespace AoC2024.Tests.Day20;

public class Day20Tests
{
    [Theory]
    [InlineData("Day20/TestInput_a.txt",5)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 20).Solve());
    }
    
    // [Theory]
    // [InlineData("Day20/TestInput_a.txt",16)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}