using AoC2023.Day6;

namespace AoC2023.Tests.Day6;

public class Day6Tests
{
    [Theory]
    [InlineData("Day6/TestInput_a.txt",288)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day6/TestInput_a.txt",71503)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}