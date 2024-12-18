using AoC2024.Day17;
using Xunit;

namespace AoC2024.Tests.Day17;

public class Day17Tests
{
    [Theory]
    [InlineData("Day17/TestInput_a.txt", "4,6,3,5,6,3,5,2,1,0")]
    public void PartOneTest(string input, string expectedResult)
    {
        var partOne = new PartOne(input);
        partOne.Solve();
        var result = string.Join(",", partOne.Output);
        Assert.Equal(expectedResult, result);
    }

    // [Theory]
    // [InlineData("Day17/TestInput_b.txt", 117440)]
    // public void PartTwoTest(string input, long expectedResult)
    // {
    //     Assert.Equal(expectedResult, new PartTwo(input).Solve());
    // }
}