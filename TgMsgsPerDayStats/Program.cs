using Newtonsoft.Json;
using TgMsgsPerDayStats;

var jsonFilePath = @"";

string jsonText = File.ReadAllText(jsonFilePath);

var obj = JsonConvert.DeserializeObject<Root>(jsonText);

foreach(var msg in obj.Messages.GroupBy(x => DateOnly.FromDateTime(x.Date.Value)))
{
    Console.WriteLine($"{msg.Key.Month}\\{msg.Key.Day} - {msg.Count()} messages");
}