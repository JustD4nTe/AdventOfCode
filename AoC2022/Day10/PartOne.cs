namespace AoC2022.Day10;

internal static class PartOne
{
    class Register
    {
        public int SignalStrength { get; private set; } = 0;
        public int X { get; private set; } = 1;
        private int _cycle;
        public int Cycle 
        { 
            get => _cycle;
            private set
            {
                _cycle = value;

                if (_cycle == 20 || _cycle == 60 || _cycle == 100 || _cycle == 140 || _cycle == 180 || _cycle == 220)
                    SignalStrength += _cycle * X;
            } 
        }

        public void Addx(int value)
        {
            Cycle++;
            Cycle++;
            X += value;
        }

        public void Noop() => Cycle++;
    }

    public static long Solution()
    {
        var register = new Register();

        foreach (var line in File.ReadAllLines("Day10/input.txt"))
        {
            if (line == "noop")
                register.Noop();
            else
                register.Addx(int.Parse(line.Split(' ')[1]));
        }

        return register.SignalStrength;
    }
}