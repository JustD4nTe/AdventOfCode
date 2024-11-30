using AoC2023.Day15;

namespace AoC2023.Tests.Day15;

public class Day15Tests
{
    [Theory]
    [InlineData("Day15/TestInput_a.txt",1320)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day15/TestInput_a.txt",145)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}