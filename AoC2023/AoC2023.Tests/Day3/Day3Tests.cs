using AoC2023.Day3;

namespace AoC2023.Tests.Day3;

public class Day3Tests
{
    [Theory]
    [InlineData("Day3/TestInput_a.txt",4361)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day3/TestInput_a.txt",467835)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}