using AoC2025.Day2;

namespace AoC2025.Tests.Day2;

public class Day2Tests
{
    [Theory]
    [InlineData("Day2/TestInput_a.txt", 1227775554)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day2/TestInput_a.txt", 4174379265)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}