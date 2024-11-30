using AoC2023.Day16;

namespace AoC2023.Tests.Day16;

public class Day16Tests
{
    [Theory]
    [InlineData("Day16/TestInput_a.txt",46)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day16/TestInput_a.txt",51)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}