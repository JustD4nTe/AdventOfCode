using AoC2024.Day2;
using Xunit;

namespace AoC2024.Tests.Day2;

public class Day2Tests
{
    [Theory]
    [InlineData("Day2/TestInput_a.txt",2)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day2/TestInput_a.txt",4)]
    [InlineData("Day2/TestInput_b.txt",16)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}