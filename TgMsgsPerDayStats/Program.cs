using Newtonsoft.Json;
using TgMsgsPerDayStats;

var jsonFilePath = @"";

string jsonText = File.ReadAllText(jsonFilePath);

var obj = JsonConvert.DeserializeObject<Root>(jsonText);

foreach(var msg in obj.Messages.GroupBy(x => DateOnly.FromDateTime(x.Date.Value)))
{
    Console.WriteLine($"{msg.Key.Month}\\{msg.Key.Day} - {msg.Count()} messages");
    var groupedByWhom = msg.GroupBy(x => x.From);
    foreach (var msgFrom in groupedByWhom)
    {
        Console.WriteLine($"From: {msgFrom.Key} - {msgFrom.Count()} messages");
    }
    Console.WriteLine(groupedByWhom.OrderByDescending(x => x.Count()).First().Key);
    Console.WriteLine();
}