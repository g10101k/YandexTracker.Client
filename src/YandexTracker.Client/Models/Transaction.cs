namespace YandexTracker.Client.Models;

public class Transition
{
    public string Id { get; set; }

    public string Self { get; set; }

    public string Display { get; set; }

    public Status To { get; set; }
}