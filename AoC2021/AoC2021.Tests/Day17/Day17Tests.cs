using AoC2021.Day17;

namespace AoC2021.Tests.Day17;

public class Day17Tests
{
    [Theory]
    [InlineData("Day17/TestInput_a.txt", 45)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day17/TestInput_a.txt", 112)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}