namespace AoC2022.Day12;

internal static class PartOne
{
    public static long Solution()
    {
        var input = File.ReadAllLines("Day12/input.txt")
                        .Select(x => x.ToCharArray())
                        .ToArray();

        var col = input[0].Length;
        var row = input.Length;

        const int xDest = 55, yDest = 20;
        const int xStart = 0, yStart = 20;

        input[yStart][xStart] = 'a';

        input[yDest][xDest] = 'z';
        //input[yDest][xDest] = 'z';

        return new GFG(col, row, yDest, xDest, yStart, xStart).MinDistance(input);
    }
    public class GFG
    {
        public record QItem(int Row, int Col, int Dist);

        private readonly int _width;
        private readonly int _height;

        private readonly int _yDest;
        private readonly int _xDest;
        
        private readonly int _yStart;
        private readonly int _xStart;

        public GFG(int col, int row, int yDest, int xDest, int yStart, int xStart)
        {
            _width = row;
            _height = col;

            _yDest = yDest;
            _xDest = xDest;

            _yStart = yStart;
            _xStart = xStart;
        }

        public int MinDistance(char[][] grid)
        {
            var source = new QItem(_yStart, _xStart, 0);

            // To keep track of visited QItems. Marking
            // blocked cells as visited.
            var visited = new bool[_width, _height];

            // applying BFS on matrix cells starting from source
            var q = new Queue<QItem>();
            q.Enqueue(source);
            visited[source.Row, source.Col] = true;
            while (q.Count > 0)
            {
                var p = q.Dequeue();

                // Destination found;
                if (p.Row == _yDest  && p.Col == _xDest)
                    return p.Dist;

                // moving up
                if (p.Row - 1 >= 0 && visited[p.Row - 1, p.Col] == false && grid[p.Row][p.Col] >= grid[p.Row - 1][p.Col] - 1)
                {
                    q.Enqueue(new QItem(p.Row - 1, p.Col, p.Dist + 1));
                    visited[p.Row - 1, p.Col] = true;
                }

                // moving down
                if (p.Row + 1 < _width && visited[p.Row + 1, p.Col] == false && grid[p.Row][p.Col] >= grid[p.Row + 1][p.Col] - 1)
                {
                    q.Enqueue(new QItem(p.Row + 1, p.Col, p.Dist + 1));
                    visited[p.Row + 1, p.Col] = true;
                }

                // moving left
                if (p.Col - 1 >= 0 && visited[p.Row, p.Col - 1] == false && grid[p.Row][p.Col] >= grid[p.Row][p.Col - 1] - 1)
                {
                    q.Enqueue(new QItem(p.Row, p.Col - 1, p.Dist + 1));
                    visited[p.Row, p.Col - 1] = true;
                }

                // moving right
                if (p.Col + 1 < _height && visited[p.Row, p.Col + 1] == false && grid[p.Row][p.Col] >= grid[p.Row][p.Col + 1] - 1)
                {
                    q.Enqueue(new QItem(p.Row, p.Col + 1, p.Dist + 1));
                    visited[p.Row, p.Col + 1] = true;
                }
            }

            return -1;
        }
    }
}