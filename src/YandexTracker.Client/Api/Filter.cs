using YandexTracker.Client.Models;

namespace YandexTracker.Client.Api;

public class Filter
{
    public string Queue { get; set; }
    public string Assignee { get; set; }
    public Status Status { get; set; }
}