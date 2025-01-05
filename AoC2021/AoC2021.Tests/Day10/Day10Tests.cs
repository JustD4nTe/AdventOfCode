using AoC2021.Day10;

namespace AoC2021.Tests.Day10;

public class Day10Tests
{
    [Theory]
    [InlineData("Day10/TestInput_a.txt",26397)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day10/TestInput_a.txt",288957)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}