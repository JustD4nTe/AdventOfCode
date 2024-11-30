using AoC.Shared;

namespace AoC2023.Day2;

public class PartTwo(string input) : Solution(input)
{
    public override long Solve()
    {
        var rawInput = File.ReadAllLines(Input);

        var games = new List<Game>();

        for (var i = 0; i < rawInput.Length; i++)
        {
            var currGame = new Game(i + 1);

            var setsOfRevealedCubesInGame = rawInput[i].Split(":")[1]
                                                       .Split(";");

            foreach (var setOfRevealedCubesInGame in setsOfRevealedCubesInGame)
            {
                var revealedCubes = setOfRevealedCubesInGame.Split(",");
                foreach (var revealedCube in revealedCubes)
                {
                    var cubeInfo = revealedCube.Split(" ");
                    var cubeCount = int.Parse(cubeInfo[1]);
                    Enum.TryParse(cubeInfo[2], true, out CubeColor cubeColor);
                    currGame.AddCubeSet(new(cubeCount, cubeColor));
                }
            }

            games.Add(currGame);
        }

        return games.Sum(x => x.GetPowerOfMinimumSetOfCubes());
    }

    private enum CubeColor
    {
        Blue,
        Red,
        Green
    }

    private record CubeSet(int CubeCount, CubeColor CubeColor);

    private record Game(int Id)
    {
        private readonly List<CubeSet> _cubeSets = [];
        public int Id = Id;

        public void AddCubeSet(CubeSet cubeSet) => _cubeSets.Add(cubeSet);

        public int GetPowerOfMinimumSetOfCubes()
            => GetSingleColorCubes(CubeColor.Blue).Max(x => x.CubeCount)
               * GetSingleColorCubes(CubeColor.Red).Max(x => x.CubeCount)
               * GetSingleColorCubes(CubeColor.Green).Max(x => x.CubeCount);

        private IEnumerable<CubeSet> GetSingleColorCubes(CubeColor cubeColor)
            => _cubeSets.Where(x => x.CubeColor == cubeColor);
    }
}