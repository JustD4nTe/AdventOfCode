using AoC2025.Day01;

namespace AoC2025.Tests.Day01;

public class Day1Tests
{
    [Theory]
    [InlineData("Day01/TestInput_a.txt", 3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day01/TestInput_a.txt", 6)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}