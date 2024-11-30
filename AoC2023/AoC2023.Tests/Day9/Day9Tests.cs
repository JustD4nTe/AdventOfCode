using AoC2023.Day9;

namespace AoC2023.Tests.Day9;

public class Day9Tests
{
    [Theory]
    [InlineData("Day9/TestInput_a.txt",114)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day9/TestInput_a.txt",2)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}