using AoC2021.Day9;

namespace AoC2021.Tests.Day9;

public class Day9Tests
{
    [Theory]
    [InlineData("Day9/TestInput_a.txt",15)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day9/TestInput_a.txt",1134)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}