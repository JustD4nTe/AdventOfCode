namespace AoC2015.Day7;

public class PartTwo
{
    private const string inputFile = "Day7/input.txt";

    private readonly OrderedDictionary<string, Instruction> wires = [];

    public ushort Solve()
    {
        var input = File.ReadAllLines(inputFile);

        InitializeWires(input);

        var wireASignal = ComputeWireSignal("a");

        wires.Clear();
        InitializeWires(input);
        wires["b"] = new(wireASignal);

        return ComputeWireSignal("a");
    }

    private void InitializeWires(string[] input)
    {
        foreach (var line in input)
        {
            var values = line.Split(" -> ");
            wires.Add(values[1], new(values[0]));
        }
    }

    private ushort ComputeWireSignal(string wire)
    {
        var instruction = wires[wire];

        ushort wireValue = instruction.Operation switch
        {
            Operation.SimpleValue => (ushort)instruction.Value!,
            Operation.DirectValue => ComputeWireSignal(instruction.WireA!),
            Operation.And => (ushort)((instruction.Value is null ? ComputeWireSignal(instruction.WireA!) : instruction.Value) & ComputeWireSignal(instruction.WireB!)),
            Operation.Or => (ushort)(ComputeWireSignal(instruction.WireA!) | ComputeWireSignal(instruction.WireB!)),
            Operation.Not => (ushort)~ComputeWireSignal(instruction.WireA!),
            Operation.LShift => (ushort)(ComputeWireSignal(instruction.WireA!) << instruction.Value!),
            Operation.RShift => (ushort)(ComputeWireSignal(instruction.WireA!) >> instruction.Value!),
            _ => throw new NotImplementedException(),
        };

        wires[wire] = new(wireValue);

        return wireValue;
    }

    record Instruction
    {
        public Operation Operation { get; private set; }
        public ushort? Value { get; private set; }
        public string? WireA { get; private set; }
        public string? WireB { get; private set; }

        public Instruction(string value)
        {
            if (ushort.TryParse(value, out var result))
            {
                Operation = Operation.SimpleValue;
                Value = result;
            }
            else if (value.Contains("NOT"))
            {
                Operation = Operation.Not;
                WireA = value["NOT ".Length..];
            }
            else if (value.Contains("AND"))
            {
                var buff = value.Split(" AND ");
                Operation = Operation.And;

                //1 AND gy -> gz :C
                if (ushort.TryParse(buff[0], out var resultAnd))
                    Value = resultAnd;
                else
                    WireA = buff[0];

                WireB = buff[1];
            }
            else if (value.Contains("OR"))
            {
                var buff = value.Split(" OR ");
                Operation = Operation.Or;
                WireA = buff[0];
                WireB = buff[1];
            }
            else if (value.Contains("LSHIFT"))
            {
                var buff = value.Split(" LSHIFT ");
                Operation = Operation.LShift;
                WireA = buff[0];
                Value = ushort.Parse(buff[1]);
            }
            else if (value.Contains("RSHIFT"))
            {
                var buff = value.Split(" RSHIFT ");
                Operation = Operation.RShift;
                WireA = buff[0];
                Value = ushort.Parse(buff[1]);
            }
            else
            {
                Operation = Operation.DirectValue;
                WireA = value;
            }
        }

        public Instruction(ushort value)
        {
            Operation = Operation.SimpleValue;
            Value = value;
        }
    }

    enum Operation
    {
        SimpleValue,
        DirectValue,
        And,
        Or,
        Not,
        LShift,
        RShift
    }
}