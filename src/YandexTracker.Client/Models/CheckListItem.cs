namespace YandexTracker.Client.Models;

/// <summary>
/// Запись чек-листа
/// </summary>
public class CheckListItem
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string TextHtml { get; set; }
    public bool Checked { get; set; }
    public User Assignee { get; set; }
    public Deadline Deadline { get; set; }
    public string ChecklistItemType { get; set; }
}