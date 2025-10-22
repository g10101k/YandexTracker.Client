using Newtonsoft.Json;

namespace YandexTracker.Client.Models;

public class SprintReference
{
    [JsonProperty("id")]
    public string Id { get; set; }
}