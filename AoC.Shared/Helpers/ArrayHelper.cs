namespace AoC.Shared.Helpers;

public static class ArrayHelper
{
    public static T[][] InitMap<T>(int length, int height, T defaultValue)
    {
        var map = new T[height][];

        for (var y = 0; y < height; y++)
        {
            map[y] = new T[length];
            for (var x = 0; x < length; x++)
            {
                map[y][x] = defaultValue;
            }
        }

        return map;
    }
}