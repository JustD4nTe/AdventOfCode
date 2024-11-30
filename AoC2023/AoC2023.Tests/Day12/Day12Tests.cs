using AoC2023.Day12;

namespace AoC2023.Tests.Day12;

public class Day12Tests
{
    [Theory]
    [InlineData("Day12/TestInput_a.txt",21)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    // [Theory]
    // [InlineData("Day12/TestInput_a.txt",8410)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}