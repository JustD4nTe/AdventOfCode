using AoC2021.Day14;

namespace AoC2021.Tests.Day14;

public class Day14Tests
{
    [Theory]
    [InlineData("Day14/TestInput_a.txt",1588)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day14/TestInput_a.txt",2188189693529)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}