using AoC2021.Day12;

namespace AoC2021.Tests.Day12;

public class Day12Tests
{
    [Theory]
    [InlineData("Day12/TestInput_a.txt",10)]
    [InlineData("Day12/TestInput_b.txt",19)]
    [InlineData("Day12/TestInput_c.txt",226)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day12/TestInput_c.txt",3509)]
    [InlineData("Day12/TestInput_b.txt",103)]
    [InlineData("Day12/TestInput_a.txt",36)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}