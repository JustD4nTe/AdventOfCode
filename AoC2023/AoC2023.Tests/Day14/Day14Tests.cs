using AoC2023.Day14;

namespace AoC2023.Tests.Day14;

public class Day14Tests
{
    [Theory]
    [InlineData("Day14/TestInput_a.txt",136)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day14/TestInput_a.txt",64)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}