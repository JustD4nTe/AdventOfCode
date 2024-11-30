using Microsoft.Win32;

namespace AoC2022.Day10;

internal static class PartTwo
{
    class Register
    {
        public int X { get; private set; } = 1;
        private int _cycle;
        public int Cycle 
        { 
            get => _cycle;
            private set
            {
                DrawPixel();
                _cycle = value;
            } 
        }

        public void Addx(int value)
        {
            Cycle++;
            Cycle++;
            X += value;
        }

        public void Noop() => Cycle++;

        private void DrawPixel()
        {
            var col = _cycle % 40;

            if(col == 0)
                Console.WriteLine();

            if (Math.Abs(col - X) <= 1)
                Console.Write('#');
            else
                Console.Write('.');
        }
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

        return 1;
    }
}