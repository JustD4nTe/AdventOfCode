namespace AoC.Shared;

public abstract class Solution(string input)
{
    protected readonly string Input = input;

    public abstract long Solve();
}