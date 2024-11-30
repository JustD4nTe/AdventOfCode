using AoC2023.Day5;

namespace AoC2023.Tests.Day5;

public class Day5Tests
{
    [Theory]
    [InlineData("Day5/TestInput_a.txt",35)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day5/TestInput_a.txt",46)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}