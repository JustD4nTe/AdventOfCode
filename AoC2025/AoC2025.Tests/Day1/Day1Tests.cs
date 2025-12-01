using AoC2025.Day1;

namespace AoC2025.Tests.Day1;

public class Day1Tests
{
    [Theory]
    [InlineData("Day1/TestInput_a.txt", 3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day1/TestInput_a.txt", 6)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}