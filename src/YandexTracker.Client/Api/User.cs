namespace YandexTracker.Client.Api;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    public string Self { get; set; }
    public string Id { get; set; }
    public string Display { get; set; }
    public string CloudUid { get; set; }
    public long PassportUid { get; set; }
}