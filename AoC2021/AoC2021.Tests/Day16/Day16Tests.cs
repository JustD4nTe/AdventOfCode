using AoC2021.Day16;

namespace AoC2021.Tests.Day16;

public class Day16Tests
{
    [Theory]
    [InlineData("Day16/TestInput_a.txt", 16)]
    [InlineData("Day16/TestInput_b.txt", 12)]
    [InlineData("Day16/TestInput_c.txt", 23)]
    [InlineData("Day16/TestInput_d.txt", 31)]
    public void PartOneTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartOne(input).Solve());
    }
    
    [Theory]
    [InlineData("Day16/TestInput_e.txt", 3)]
    [InlineData("Day16/TestInput_f.txt", 54)]
    [InlineData("Day16/TestInput_g.txt", 7)]
    [InlineData("Day16/TestInput_h.txt", 9)]
    [InlineData("Day16/TestInput_i.txt", 1)]
    [InlineData("Day16/TestInput_j.txt", 0)]
    [InlineData("Day16/TestInput_k.txt", 0)]
    [InlineData("Day16/TestInput_l.txt", 1)]
    public void PartTwoTest(string input, long expectedResult)
    {
        Assert.Equal(expectedResult, new PartTwo(input).Solve());
    }
}