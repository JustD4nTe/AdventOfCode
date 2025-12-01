using AoC.Shared;

namespace AoC2025.Day1;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input)
            .Select(Rotation.Parse)
            .ToArray();

        var dial = 50;
        var result = 0;

        for (var i = 0; i < rawInput.Length; i++)
        {
            var rotation = rawInput[i];
            dial += rotation.D switch
            {
                Direction.Left => -rotation.StepCount,
                Direction.Right => rotation.StepCount,
                _ => throw new ArgumentException("Invalid direction")
            };

            while (dial < 0)
            {
                dial += 100;
                result++;
            };

            while (dial >= 100)
            {
                dial -= 100;
                result++;
            };

        }

        return result;
    }

    private enum Direction
    {
        Left,
        Right
    }

    private record class Rotation(Direction D, int StepCount)
    {
        public static Rotation Parse(string input)
        {
            var direction = input[0] switch
            {
                'L' => Direction.Left,
                'R' => Direction.Right,
                _ => throw new ArgumentException("Invalid direction")
            };
            var stepCount = int.Parse(input[1..]);
            return new Rotation(direction, stepCount);
        }
    }
}