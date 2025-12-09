using AoC.Shared.ValueObjects;

namespace AoC.Shared;

public static class PlotHelper
{
    public static void SavePlot(Position2D[] p)
    {
        ScottPlot.Plot myPlot = new();
        
        var xs = p.Select(x => x.X).ToArray();
        var xy = p.Select(y => y.Y).ToArray();

        myPlot.Add.Scatter(xs, xy);

        myPlot.SavePng("demo.png", 4000, 3000);
    }
}
