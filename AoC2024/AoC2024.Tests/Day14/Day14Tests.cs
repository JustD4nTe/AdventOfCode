using AoC2024.Day14;
using Xunit;

namespace AoC2024.Tests.Day14;

public class Day14Tests
{
    [Theory]
    [InlineData("Day14/TestInput_a.txt",12)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 11, 7).Solve());
    }
    
    // [Theory]
    // [InlineData("Day14/TestInput_a.txt",80)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}