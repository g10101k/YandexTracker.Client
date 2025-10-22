using Newtonsoft.Json;

namespace YandexTracker.Client.Models;

public class Resolution
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("key")]
    public string Key { get; set; }
}