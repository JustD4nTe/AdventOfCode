using AoC2023.Day2;

namespace AoC2023.Tests.Day2;

public class Day2Tests
{
    [Theory]
    [InlineData("Day2/TestInput_a.txt",8)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day2/TestInput_a.txt",2286)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}