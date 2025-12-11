using AoC2025.Day02;

namespace AoC2025.Tests.Day02;

public class Day2Tests
{
    [Theory]
    [InlineData("Day02/TestInput_a.txt", 1227775554)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }

    [Theory]
    [InlineData("Day02/TestInput_a.txt", 4174379265)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}