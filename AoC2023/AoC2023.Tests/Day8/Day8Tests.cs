using AoC2023.Day8;

namespace AoC2023.Tests.Day8;

public class Day8Tests
{
    [Theory]
    [InlineData("Day8/TestInput_a.txt",2)]
    [InlineData("Day8/TestInput_b.txt",6)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day8/TestInput_c.txt",6)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}