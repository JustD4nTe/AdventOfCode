using AoC.Shared;

namespace AoC2021.Day10;

public class PartTwo(string input) : Solution(input)
{
    private readonly Dictionary<char, int> _punctation = new()
    {
        ['('] = 1,
        ['['] = 2,
        ['{'] = 3,
        ['<'] = 4,
    };

    private readonly char[] _openBrackets = ['(', '[', '{', '<'];
    private readonly char[] _closeBrackets = [')', ']', '}', '>'];

    public override long Solve()
    {
        var navigationSubSystem = File.ReadAllLines(Input);


        var scores = new List<long>();
        
        foreach (var line in navigationSubSystem)
        {
            var stack = new Stack<char>();
            var isCorrupted = false;
            
            foreach (var bracket in line)
            {
                if (_openBrackets.Contains(bracket))
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
                }

                isCorrupted = true;
                break;
            }

            if(isCorrupted)
                continue;
            
            var score = 0L;
            
            while (stack.Count > 0)
            {
                score *= 5;
                score += _punctation[stack.Pop()];
            }
            
            scores.Add(score);
        }

        return scores.Order().ElementAt(scores.Count / 2);
    }
}