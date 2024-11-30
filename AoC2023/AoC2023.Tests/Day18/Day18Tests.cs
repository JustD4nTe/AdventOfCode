using AoC2023.Day18;

namespace AoC2023.Tests.Day18;

public class Day18Tests
{
    [Theory]
    [InlineData("Day18/TestInput_a.txt",62)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    // [Theory]
    // [InlineData("Day18/TestInput_a.txt",51)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}