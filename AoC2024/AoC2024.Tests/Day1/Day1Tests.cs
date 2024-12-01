using AoC2024.Day1;
using Xunit;

namespace AoC2024.Tests.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData("Day1/TestInput_a.txt",11)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day1/TestInput_a.txt",31)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}