using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using OxyPlot.SkiaSharp;

namespace TgMsgsPerDayStats;

public static class ChartService
{
    public static void GenerateChart(List<DataPoint> messagesForChart)
    {
        var plotModel = new PlotModel { Title = "Message Count Over Time" };
        var lineSeries = new LineSeries
        {
            LineJoin = LineJoin.Round,
            Color = OxyColor.FromArgb(255, 0, 0, 0),
        };
        lineSeries.Points.AddRange(messagesForChart);
        plotModel.Series.Add(lineSeries);
        plotModel.Background = OxyColor.FromArgb(255, 255, 255, 255);

        plotModel.Axes.Add(new DateTimeAxis
        {
            Position = AxisPosition.Bottom,
            StringFormat = "MM/dd",
            Title = "Date"
        });
        plotModel.Axes.Add(new LinearAxis
        {
            Position = AxisPosition.Left,
            Title = "Number of Messages",
        });

        GenerateImage(plotModel, "MessageCountChart.png");
    }

    private static void GenerateImage(IPlotModel plotModel, string filePath)
    {
        var exporter = new PngExporter { Width = 1500, Height = 800 };

        using var stream = File.Create(filePath);
        exporter.Export(plotModel, stream);
    }
}
