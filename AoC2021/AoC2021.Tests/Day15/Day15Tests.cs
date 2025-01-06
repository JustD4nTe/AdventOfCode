using AoC2021.Day15;

namespace AoC2021.Tests.Day15;

public class Day15Tests
{
    [Theory]
    [InlineData("Day15/TestInput_a.txt",40)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day15/TestInput_a.txt",315)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}