using AoC2025.Day6;

namespace AoC2025.Tests.Day6;

public class Day6Tests
{
    [Theory]
    [InlineData("Day6/TestInput_a.txt", 4277556)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day6/TestInput_a.txt", 3263827)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}