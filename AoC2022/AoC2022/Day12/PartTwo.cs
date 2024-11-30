namespace AoC2022.Day12;

internal static class PartTwo
{
    public static long Solution()
    {
        var input = File.ReadAllLines("Day12/input.txt")
                        .Select(x => x.ToCharArray())
                        .ToArray();

        var col = input[0].Length;
        var row = input.Length;

        const int xDest = 55, yDest = 20;

        input[20][0] = 'a';
        input[yDest][xDest] = 'z';

        var startPositions = new List<(int, int)>();

        for (int i = 0; i < row; i++)
        {
            for (var j = 0; j < col; j++)
            {
                if (input[i][j] == 'a')
                    startPositions.Add((i, j));
            }
        }

        var distances = new List<int>();

        foreach (var (yStart, xStart) in startPositions)
        {
            var distance = GFG.MinDistance(input, col, row, xStart, yStart, xDest, yDest);
            distances.Add(distance);
        }

        return distances.Where(x => x > 0).Min();
    }
    public static class GFG
    {
        public record QItem(int Y, int X, int Dist);

        public static int MinDistance(char[][] grid, int xMax, int yMax, int xStart, int yStart, int xDest, int yDest)
        {
            var source = new QItem(yStart, xStart, 0);

            // To keep track of visited QItems. Marking
            // blocked cells as visited.
            var visited = new bool[yMax, xMax];

            // applying BFS on matrix cells starting from source
            var q = new Queue<QItem>();
            q.Enqueue(source);
            visited[source.Y, source.X] = true;
            while (q.Count > 0)
            {
                var p = q.Dequeue();

                // Destination found;
                if (p.Y == yDest  && p.X == xDest)
                    return p.Dist;

                // moving up
                if (p.Y - 1 >= 0 && visited[p.Y - 1, p.X] == false && grid[p.Y][p.X] >= grid[p.Y - 1][p.X] - 1)
                {
                    q.Enqueue(new QItem(p.Y - 1, p.X, p.Dist + 1));
                    visited[p.Y - 1, p.X] = true;
                }

                // moving down
                if (p.Y + 1 < yMax && visited[p.Y + 1, p.X] == false && grid[p.Y][p.X] >= grid[p.Y + 1][p.X] - 1)
                {
                    q.Enqueue(new QItem(p.Y + 1, p.X, p.Dist + 1));
                    visited[p.Y + 1, p.X] = true;
                }

                // moving left
                if (p.X - 1 >= 0 && visited[p.Y, p.X - 1] == false && grid[p.Y][p.X] >= grid[p.Y][p.X - 1] - 1)
                {
                    q.Enqueue(new QItem(p.Y, p.X - 1, p.Dist + 1));
                    visited[p.Y, p.X - 1] = true;
                }

                // moving right
                if (p.X + 1 < xMax && visited[p.Y, p.X + 1] == false && grid[p.Y][p.X] >= grid[p.Y][p.X + 1] - 1)
                {
                    q.Enqueue(new QItem(p.Y, p.X + 1, p.Dist + 1));
                    visited[p.Y, p.X + 1] = true;
                }
            }

            return -1;
        }
    }
}