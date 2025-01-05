using AoC.Shared;

namespace AoC2021.Day10;

public class PartOne(string input) : Solution(input)
{
    private readonly Dictionary<char, int> _punctation = new()
    {
        [')'] = 3,
        [']'] = 57,
        ['}'] = 1197,
        ['>'] = 25137,
    };

    private readonly char[] _openBrackets = ['(', '[', '{', '<'];

    public override long Solve()
    {
        var navigationSubSystem = File.ReadAllLines(Input);

        var points = 0L;
        
        foreach (var line in navigationSubSystem)
        {
            var stack = new Stack<char>();

            foreach (var bracket in line)
            {
                if(_openBrackets.Contains(bracket))
                {
                    stack.Push(bracket);
                    continue;
                }

                var open = stack.Pop();
                
                switch (open)
                {
                    case '(' when bracket == ')':
                    case '[' when bracket == ']':
                    case '{' when bracket == '}':
                    case '<' when bracket == '>':
                        continue;
                    default:
                        points += _punctation[bracket];
                        break;
                }
            }
        }

        return points;
    }
}