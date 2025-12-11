using AoC2025.Day06;

namespace AoC2025.Tests.Day06;

public class Day6Tests
{
    [Theory]
    [InlineData("Day06/TestInput_a.txt", 4277556)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day06/TestInput_a.txt", 3263827)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}