using AoC2015.Day7;
using System.Diagnostics;

var sw = Stopwatch.StartNew();

Console.WriteLine((new PartOne()).Solve());
Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds}ms"); 

Console.WriteLine((new PartTwo()).Solve());
Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds}ms");