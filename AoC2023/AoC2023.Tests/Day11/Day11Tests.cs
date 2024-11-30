using AoC2023.Day11;

namespace AoC2023.Tests.Day11;

public class Day11Tests
{
    [Theory]
    [InlineData("Day11/TestInput_a.txt",374)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day11/TestInput_a.txt",8410)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}