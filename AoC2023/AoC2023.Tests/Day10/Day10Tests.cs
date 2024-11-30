using AoC2023.Day10;

namespace AoC2023.Tests.Day10;

public class Day10Tests
{
    [Theory]
    [InlineData("Day10/TestInput_a.txt",4)]
    [InlineData("Day10/TestInput_b.txt",8)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day10/TestInput_c.txt",4)]
    [InlineData("Day10/TestInput_d.txt",4)]
    [InlineData("Day10/TestInput_e.txt",8)]
    [InlineData("Day10/TestInput_f.txt",10)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}