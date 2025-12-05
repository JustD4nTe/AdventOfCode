namespace AoC.Shared.ValueObjects;

public record AoCRange(long Left, long Right)
{
    public static AoCRange CreateEmpty() 
        => new(0, 0);

    public bool IsEmpty()
        => Left == 0 && Right == 0;

    public bool IsInRange(long v) 
        => Left <= v && Right >= v;

    public bool IsInRange(AoCRange subRange) 
        => Left <= subRange.Left && Right >= subRange.Right;

    public long ValueCount() 
        => Right - Left + 1;
}