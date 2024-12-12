using AoC2024.Day12;
using Xunit;

namespace AoC2024.Tests.Day12;

public class Day12Tests
{
    [Theory]
    [InlineData("Day12/TestInput_a.txt",140)]
    [InlineData("Day12/TestInput_b.txt",772)]
    [InlineData("Day12/TestInput_c.txt",1930)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day12/TestInput_a.txt",80)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}