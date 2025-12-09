using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2025.Day9;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var redTilesPositions = File.ReadAllLines(Input)
            .Select(x => x.Split(",").Select(int.Parse).ToArray())
            .Select(y => new Position2D(y[0], y[1]))
            .ToArray();

        //PlotHelper.SavePlot(redTilesPositions);

        // get core points based on plot
        var corePoints = redTilesPositions.Where(x => x.Y > 48000 && x.Y < 51000 && x.X > 94000 && x.X < 96000).ToArray();
        var upper = corePoints[0];
        var lower = corePoints[1];

        // limit available points by height
        var maxUpperRectHeight = redTilesPositions.Where(x => x.X >= upper.X && x.Y > upper.Y).Max(x => x.Y);
        var maxLowerRectHeight = redTilesPositions.Where(x => x.X >= lower.X && x.Y < lower.Y).Min(x => x.Y);

        // get all available points, and sort them to get valid possible rectangles
        var forUpper = redTilesPositions.Where(x => x.Y > upper.Y && x.Y <= maxUpperRectHeight && x.X <= upper.X).Order(new ComparerForUpper()).ToArray();
        var forLower = redTilesPositions.Where(x => x.Y < lower.Y && x.Y >= maxLowerRectHeight && x.X <= lower.X).Order(new ComparerForLower()).ToArray();

        // get only points which allow to get rectangle inside circle
        List<Position2D> up = GetAllowedPoints(forUpper);
        List<Position2D> down = GetAllowedPoints(forLower);

        // calculate max rectangle for upper and lower core separator
        var maxForUpper = SearchForMaxSize(upper, up);
        var maxForLower = SearchForMaxSize(lower, down);

        return maxForUpper > maxForLower ? maxForUpper : maxForLower;
    }

    private class ComparerForUpper : IComparer<Position2D>
    {
        public int Compare(Position2D? x, Position2D? y)
            => x.Y == y.Y
                ? x.X < y.X ? -1 : 1
                : x.Y < y.Y ? -1 : 1;
    }

    private class ComparerForLower : IComparer<Position2D>
    {
        public int Compare(Position2D? x, Position2D? y)
            => x.Y == y.Y
                ? x.X < y.X ? -1 : 1
                : x.Y > y.Y ? -1 : 1;
    }

    private static List<Position2D> GetAllowedPoints(Position2D[] p)
    {
        var allowed = new List<Position2D>() { p[0] };

        for (var i = 0; i < p.Length; i++)
        {
            if (allowed[^1].X <= p[i].X)
                allowed.Add(p[i]);
        }

        return allowed;
    }

    private static long SearchForMaxSize(Position2D p, List<Position2D> forP)
    {
        var maxSize = 0L;

        for (var i = 0; i < forP.Count; i++)
        {
            long xL = GetTileLength(forP[i].X, p.X);
            long yL = GetTileLength(forP[i].Y, p.Y);

            var square = xL * yL;

            if (maxSize < square)
                maxSize = square;
        }

        return maxSize;
    }

    private static long GetTileLength(int t1, int t2)
        => t1 > t2 ? t1 - t2 + 1 : t2 - t1 + 1;
}