using System.Diagnostics.CodeAnalysis;
using AoC.Shared;

namespace AoC2023.Day5;

public class PartTwo(string input): Solution(input)
{
    private record Range(long Start, long End) : IEqualityComparer<Range>
    {
        public bool Equals(Range? x, Range? y)
            => x.Start == y.Start && x.End == y.End;

        public int GetHashCode([DisallowNull] Range obj)
        {
            throw new NotImplementedException();
        }
    }

    public override long Solve()
    {
        var seedToSoilMap = new Dictionary<Range, Range>();
        var soilToFertilizerMap = new Dictionary<Range, Range>();
        var fertilizerToWaterMap = new Dictionary<Range, Range>();
        var waterToLightMap = new Dictionary<Range, Range>();
        var lightToTemperatureMap = new Dictionary<Range, Range>();
        var temperatureToHumidityMap = new Dictionary<Range, Range>();
        var humidityToLocationMap = new Dictionary<Range, Range>();

        var rawInput = File.ReadAllLines(Input);
        var index = 0;

        var seedsToPlant = rawInput[index][7..].Split(" ")
                                        .Select(long.Parse)
                                        .ToArray();

        var seeds = new List<Range>();

        for (var i = 0; i < seedsToPlant.Length; i += 2)
        {
            var start = seedsToPlant[i];
            var end = seedsToPlant[i] + seedsToPlant[i + 1] - 1;
            seeds.Add(new(start, end));
        }

        index += 3;

        ParseMapping(ref index, seeds, seedToSoilMap, rawInput);
        ParseMapping(ref index, seedToSoilMap.Values, soilToFertilizerMap, rawInput);
        ParseMapping(ref index, soilToFertilizerMap.Values, fertilizerToWaterMap, rawInput);
        ParseMapping(ref index, fertilizerToWaterMap.Values, waterToLightMap, rawInput);
        ParseMapping(ref index, waterToLightMap.Values, lightToTemperatureMap, rawInput);
        ParseMapping(ref index, lightToTemperatureMap.Values, temperatureToHumidityMap, rawInput);
        ParseMapping(ref index, temperatureToHumidityMap.Values, humidityToLocationMap, rawInput);

        return humidityToLocationMap.Values.Min(x => x.Start);
    }

    private static void ParseMapping(ref int index, IEnumerable<Range> seeds, Dictionary<Range, Range> map, string[] rawInput)
    {
        var enumOne = seeds as Range[] ?? seeds.ToArray();
        while (rawInput.Length > index && rawInput[index] != string.Empty)
        {
            var rawMap = rawInput[index].Split(" ")
                                        .Select(long.Parse)
                                        .ToArray();

            var destStart = rawMap[0];
            var sourceStart = rawMap[1];
            var rangeLength = rawMap[2];
            var sourceEnd = sourceStart + rangeLength - 1;

            var rangesToMap = new List<Range>();

            // case [1]: entire mapping is in seed range
            rangesToMap.AddRange(enumOne.Where(x => x.Start <= sourceStart && x.End >= sourceEnd && sourceStart <= x.End && sourceEnd >= x.Start));

            // case [2]: only end is in seed range
            rangesToMap.AddRange(enumOne.Where(x => x.Start >= sourceStart && x.End >= sourceEnd && sourceStart <= x.End && sourceEnd >= x.Start));

            // case [3]: only start is in seed range
            rangesToMap.AddRange(enumOne.Where(x => x.Start <= sourceStart && x.End <= sourceEnd && sourceStart <= x.End && sourceEnd >= x.Start));

            // case [4]: mapping is larger than seed range
            rangesToMap.AddRange(enumOne.Where(x => x.Start >= sourceStart && x.End <= sourceEnd && sourceStart <= x.End && sourceEnd >= x.Start));

            rangesToMap = rangesToMap.Distinct().ToList();

            foreach (var rangeToMap in rangesToMap)
            {
                var internalStart = Math.Max(rangeToMap.Start, sourceStart);
                var internalEnd = Math.Min(rangeToMap.End, sourceEnd);
                var diffStart = internalStart - sourceStart;
                var diffLength = internalEnd - internalStart;

                destStart += diffStart;
                var destEnd = destStart + diffLength;

                var source = new Range(internalStart, internalEnd);

                map[source] = new Range(destStart, destEnd);
            }

            index++;
        }

        Fill(enumOne, map);

        index += 2;
    }



    private static void Fill(Range[] seeds, Dictionary<Range, Range> map)
    {
        foreach (var seed in seeds)
        {
            var mappedSeeds = map.Keys.Where(x => seed.Start <= x.Start && seed.End >= x.End).OrderBy(x => x.Start);
            
            // when range doesn't contain any mappings
            if (!mappedSeeds.Any())
            {
                map[seed] = seed;
                continue;
            }

            var defaultMappings = new List<Range>();

            // create range from seed range start to first mapping
            if (seed.Start != mappedSeeds.First().Start)
                defaultMappings.Add(new(seed.Start, mappedSeeds.First().Start - 1));

            // fill every empty space between mappings
            for (var i = 0; i < mappedSeeds.Count() - 1; i++)
            {
                // skip when two mappigns are close enough 
                // (doesn't have any seed left between)
                if (mappedSeeds.ElementAt(i).End + 1 == mappedSeeds.ElementAt(i + 1).Start)
                    continue;

                defaultMappings.Add(new(mappedSeeds.ElementAt(i).End + 1, mappedSeeds.ElementAt(i + 1).Start));
            }

            // crate range from last mapping to end of seed range
            if (mappedSeeds.Last().End != seed.End)
                defaultMappings.Add(new(mappedSeeds.Last().End, seed.End));

            // add default ranges
            foreach (var defaultMapping in defaultMappings)
                map[defaultMapping] = defaultMapping;
        }
    }
}