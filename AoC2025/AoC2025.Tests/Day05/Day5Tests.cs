using AoC2025.Day05;

namespace AoC2025.Tests.Day05;

public class Day5Tests
{
    [Theory]
    [InlineData("Day05/TestInput_a.txt", 3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 5).Solve());
    }

    [Theory]
    [InlineData("Day05/TestInput_a.txt", 16)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input, 5).Solve());
    }
}