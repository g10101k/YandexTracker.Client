namespace YandexTracker.Client.Api;

public class Department
{
    public int Id { get; set; }
    public string Display { get; set; }
    public object Deleted { get; set; }
    public string GroupType { get; set; }
    public object Url { get; set; }
    public int TotalUsersCount { get; set; }
    public int ExternalsCount { get; set; }
    public int LicenseType { get; set; }
    public object InheritedLicenseType { get; set; }
    public string SourceId { get; set; }
    public string GroupCollabId { get; set; }
    public object HasQueueLead { get; set; }
    public object IsMyGroup { get; set; }
    public object ServiceId { get; set; }
    public object RoleScope { get; set; }
}