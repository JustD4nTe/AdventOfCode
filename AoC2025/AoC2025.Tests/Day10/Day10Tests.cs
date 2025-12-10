using AoC2025.Day10;

namespace AoC2025.Tests.Day10;

public class Day10Tests
{
    [Theory]
    [InlineData("Day10/TestInput_a.txt", 7)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day10/TestInput_a.txt", 33)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}