using OxyPlot;
using OxyPlot.Axes;
using System.Text.Json;
using TgMsgsPerDayStats;

var jsonFilePath = @"";
string jsonText = File.ReadAllText(jsonFilePath);
var jsonSettings = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = false,
};
var obj = JsonSerializer.Deserialize<Root>(jsonText);

var messagesForChart = new List<DataPoint>();

foreach (var msg in obj.Messages.GroupBy(x => DateOnly.FromDateTime(x.Date.Value)))
{
    var sumOfAllMessages = msg.Count();
    Console.WriteLine($"{msg.Key.Month}\\{msg.Key.Day} - {sumOfAllMessages} messages");
    var groupedByWhom = msg.GroupBy(x => x.From);
    foreach (var msgFrom in groupedByWhom)
    {
        Console.WriteLine($"From: {msgFrom.Key} - {msgFrom.Count()} messages");
    }
    Console.WriteLine(groupedByWhom.OrderByDescending(x => x.Count()).First().Key);
    Console.WriteLine();

    var date = msg.Key;
    messagesForChart.Add(new DataPoint(DateTimeAxis.ToDouble(new DateTime(date.Year, date.Month, date.Day)), sumOfAllMessages));
}

ChartService.GenerateChart(messagesForChart);
