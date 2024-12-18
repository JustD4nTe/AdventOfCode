using AoC.Shared;

namespace AoC2024.Day17;

public class PartOne(string input) : Solution(input)
{
    private long _registerA;
    private long _registerB;
    private long _registerC;

    public List<byte> Output = [];

    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        _registerA = long.Parse(rawInput[0].Split(": ")[1]);
        _registerB = long.Parse(rawInput[1].Split(": ")[1]);
        _registerC = long.Parse(rawInput[2].Split(": ")[1]);

        var program = rawInput[4].Split(": ")[1].Split(",").Select(byte.Parse).ToArray();

        var instructionPointer = 0;

        do
        {
            var instruction = program[instructionPointer];
            var operand = program[instructionPointer + 1];

            switch (instruction)
            {
                case 0: // adv
                    _registerA /= (int)Math.Pow(2, GetComboOperand(operand));
                    break;
                case 1: // bxl
                    _registerB ^= operand;
                    break;
                case 2: // bst
                    _registerB = GetComboOperand(operand) % 8;
                    break;
                case 3: // jnz
                    if (_registerA != 0)
                    {
                        instructionPointer = operand;
                        continue;
                    }

                    break;
                case 4: // bxc
                    _registerB ^= _registerC;
                    break;
                case 5: // out
                    Output.Add((byte)(GetComboOperand(operand) % 8));
                    break;
                case 6: // bdv
                    _registerB = _registerA / (int)Math.Pow(2, GetComboOperand(operand));
                    break;
                case 7: // cdv
                    _registerC = _registerA / (int)Math.Pow(2, GetComboOperand(operand));
                    break;
            }

            instructionPointer += 2;
        } while (instructionPointer < program.Length);

        Console.WriteLine(string.Join(',', Output));

        return -1;
    }

    private long GetComboOperand(byte operand)
        => operand switch
        {
            <= 3 => operand,
            4 => _registerA,
            5 => _registerB,
            6 => _registerC,
            _ => throw new ArgumentException()
        };
}