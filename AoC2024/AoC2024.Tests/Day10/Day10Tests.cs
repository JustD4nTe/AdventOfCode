using AoC2024.Day10;
using Xunit;

namespace AoC2024.Tests.Day10;

public class Day10Tests
{
    [Theory]
    [InlineData("Day10/TestInput_a.txt",36)]
    [InlineData("Day10/TestInput_b.txt",2)]
    [InlineData("Day10/TestInput_c.txt",4)]
    [InlineData("Day10/TestInput_d.txt",3)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day10/TestInput_a.txt",81)]
    [InlineData("Day10/TestInput_e.txt",3)]
    [InlineData("Day10/TestInput_f.txt",13)]
    [InlineData("Day10/TestInput_g.txt",227)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}