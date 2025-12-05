using AoC2025.Day5;

namespace AoC2025.Tests.Day5;

public class Day5Tests
{
    [Theory]
    [InlineData("Day5/TestInput_a.txt", 3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input, 5).Solve());
    }

    [Theory]
    [InlineData("Day5/TestInput_a.txt", 16)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input, 5).Solve());
    }
}