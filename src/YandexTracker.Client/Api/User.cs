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
    public string Login { get; set; }
    public string Gender { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Department Department { get; set; }
    public string Email { get; set; }
    public bool External { get; set; }
    public bool Robot { get; set; }
    public int EffectiveLicenseType { get; set; }
    public string Position { get; set; }
    public long TrackerUid { get; set; }
}