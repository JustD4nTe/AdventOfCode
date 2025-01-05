using AoC.Shared;

namespace AoC2021.Day4;

public class PartOne(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllText(Input).Split("\r\n\r\n").ToArray();

        var drawNumbers = rawInput[0].Split(",").Select(int.Parse).ToArray();

        var boards = rawInput[1..]
            .Select(x => x
                .Split("\r\n")
                .Select(y => y
                    .Trim()
                    .Replace("  ", " ")
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray())
                .ToArray())
            .ToArray();
        
        for (var i = 0; i < drawNumbers.Length; i++)
        {
            for (var j = 0; j < boards.Length; j++)
            {
                MarkNumber(boards[j], drawNumbers[i]);
                
                if(!IsWinner(boards[j]))
                    continue;
                
                var sumOfUnmarkedNumbers = boards[j].SelectMany(x => x)
                    .Where(x => x != -1)
                    .Sum();

                return sumOfUnmarkedNumbers * drawNumbers[i];
            }
        }

        return -1;
    }
    
    private static void MarkNumber(int[][] board, int number)
    {
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == number)
                {
                    board[i][j] = -1;
                    return;
                }
            }
        }
    }

    private static bool IsWinner(int[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            // horizontal
            if (board[i].All(x => x == -1))
                return true;

            // vertical
            if (board.Select(x => x[i]).All(x => x == -1))
                return true;
        }

        return false;
    }
}