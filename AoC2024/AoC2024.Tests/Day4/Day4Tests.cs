using AoC2024.Day4;
using Xunit;

namespace AoC2024.Tests.Day4;

public class Day4Tests
{
    [Theory]
    [InlineData("Day4/TestInput_a.txt",18)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day4/TestInput_a.txt",9)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}