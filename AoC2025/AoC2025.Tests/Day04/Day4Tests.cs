using AoC2025.Day04;

namespace AoC2025.Tests.Day04;

public class Day4Tests
{
    [Theory]
    [InlineData("Day04/TestInput_a.txt", 13)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day04/TestInput_a.txt", 43)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}