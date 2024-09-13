namespace YandexTracker.Client.Models;

/// <summary>
/// Дедлайн для чек-листа
/// </summary>
public class Deadline
{
    public DateTimeOffset? Date { get; set; }
    public string DeadlineType { get; set; }
    public bool IsExceeded { get; set; }
}