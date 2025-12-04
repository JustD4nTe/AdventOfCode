using AoC2025.Day4;

namespace AoC2025.Tests.Day4;

public class Day4Tests
{
    [Theory]
    [InlineData("Day4/TestInput_a.txt", 13)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day4/TestInput_a.txt", 43)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}