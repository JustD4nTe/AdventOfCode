using AoC2024.Day15;
using Xunit;

namespace AoC2024.Tests.Day15;

public class Day15Tests
{
    [Theory]
    [InlineData("Day15/TestInput_a.txt",2028)]
    [InlineData("Day15/TestInput_b.txt",10092)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day15/TestInput_b.txt",9021)]
    [InlineData("Day15/TestInput_c.txt",618)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}