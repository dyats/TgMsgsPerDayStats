using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TgMsgsPerDayStats;
public class Message
{
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonProperty("date_unixtime", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("date_unixtime")]
    public string DateUnixtime { get; set; }

    [JsonProperty("from", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("from")]
    public string From { get; set; }

    [JsonProperty("from_id", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("from_id")]
    public string FromId { get; set; }
}

public class Root
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("messages")]
    public List<Message> Messages { get; set; }
}

public class TextEntity
{
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    [JsonPropertyName("text")]
    public string Text { get; set; }
}

