using Newtonsoft.Json;

namespace YandexTracker.Client;

public class SprintReference
{
    [JsonProperty("id")]
    public string Id { get; set; }
}