using AoC2023.Day7;

namespace AoC2023.Tests.Day7;

public class Day7Tests
{
    [Theory]
    [InlineData("Day7/TestInput_a.txt",6440)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day7/TestInput_a.txt",5905)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}