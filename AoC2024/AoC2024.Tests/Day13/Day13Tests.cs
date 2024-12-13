using AoC2024.Day13;
using Xunit;

namespace AoC2024.Tests.Day13;

public class Day13Tests
{
    [Theory]
    [InlineData("Day13/TestInput_a.txt",480)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    // [Theory]
    // [InlineData("Day13/TestInput_a.txt",80)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}