using AoC.Shared;
using AoC.Shared.ValueObjects;

namespace AoC2021.Day9;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var heatmap = File.ReadAllLines(Input)
            .Select(x => x
                .ToCharArray()
                .Select(y =>
                    int.Parse(y.ToString()))
                .ToArray())
            .ToArray();

        var result = new List<int>();
        
        for (var y = 0; y < heatmap.Length; y++)
        {
            for (var x = 0; x < heatmap[y].Length; x++)
            {
                if (heatmap[y][x] == 9)
                    continue;

                var queue = new Queue<Position>();
                queue.Enqueue(new Position(x, y));

                var size = 0;

                do
                {
                    var curr = queue.Dequeue();

                    if (heatmap[curr.Y][curr.X] == 9)
                        continue;

                    heatmap[curr.Y][curr.X] = 9;
                    size++;

                    // up
                    if (curr.Y > 0)
                        queue.Enqueue(curr with {Y = curr.Y - 1});
                    
                    // right
                    if (curr.X + 1 < heatmap[curr.Y].Length)
                        queue.Enqueue(curr with {X = curr.X + 1});
                    
                    // down
                    if(curr.Y + 1 < heatmap.Length)
                        queue.Enqueue(curr with {Y = curr.Y + 1});
                    
                    // left
                    if(curr.X > 0)
                        queue.Enqueue(curr with {X = curr.X - 1});
                    
                } while (queue.Count > 0);

                result.Add(size);
            }
        }

        result = result.OrderDescending().ToList();
        
        return result[0] * result[1] * result[2];
    }
}