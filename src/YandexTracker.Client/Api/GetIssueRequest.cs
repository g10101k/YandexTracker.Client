namespace YandexTracker.Client.Api;

public class GetIssueRequest
{
    public Filter? Filter { get; set; }
    public string Query { get; set; }
    public string Order { get; set; }
}