using Newtonsoft.Json;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using TgMsgsPerDayStats;

var jsonFilePath = @"/Users/dyats/Downloads/Telegram Desktop/ChatExport_2023-12-22/result.json";
string jsonText = File.ReadAllText(jsonFilePath);
var obj = JsonConvert.DeserializeObject<Root>(jsonText);

var messageCounts = new List<DataPoint>();

foreach (var msg in obj.Messages.GroupBy(x => DateOnly.FromDateTime(x.Date.Value)))
{
    Console.WriteLine($"{msg.Key.Month}\\{msg.Key.Day} - {msg.Count()} messages");
    var groupedByWhom = msg.GroupBy(x => x.From);
    foreach (var msgFrom in groupedByWhom)
    {
        Console.WriteLine($"From: {msgFrom.Key} - {msgFrom.Count()} messages");
    }
    Console.WriteLine(groupedByWhom.OrderByDescending(x => x.Count()).First().Key);
    Console.WriteLine();

    var date = msg.Key;
    messageCounts.Add(new DataPoint(DateTimeAxis.ToDouble(new DateTime(date.Year, date.Month, date.Day)), msg.Count()));
}

var plotModel = new PlotModel { Title = "Message Count Over Time" };
var lineSeries = new LineSeries();
lineSeries.Points.AddRange(messageCounts);
plotModel.Series.Add(lineSeries);

plotModel.Axes.Add(new DateTimeAxis
{
    Position = AxisPosition.Bottom,
    StringFormat = "MM\\dd",
    Title = "Date"
});

plotModel.Axes.Add(new LinearAxis
{
    Position = AxisPosition.Left,
    Title = "Number of Messages"
});

ExportPlot(plotModel, "MessageCountGraph.png");

static void ExportPlot(PlotModel plotModel, string filePath)
{
    var exporter = new OxyPlot.SkiaSharp.PngExporter { Width = 1000, Height = 500 };
    using (var stream = File.Create(filePath))
    {
        exporter.Export(plotModel, stream);
    }
}
