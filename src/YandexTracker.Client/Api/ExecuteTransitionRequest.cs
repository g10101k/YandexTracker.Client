using Newtonsoft.Json;

namespace YandexTracker.Client;

public class ExecuteTransitionRequest : Dictionary<string, object>
{
    /// <summary>
    /// Комментарий к задаче при выполнении перехода
    /// </summary>
    [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
    public string Comment
    {
        get => ContainsKey("comment") ? this["comment"] as string : null;
        set => this["comment"] = value;
    }
    
    // Можно добавить свойства для часто используемых полей
    
    /// <summary>
    /// Назначить исполнителя
    /// </summary>
    [JsonProperty("assignee", NullValueHandling = NullValueHandling.Ignore)]
    public string Assignee
    {
        get => ContainsKey("assignee") ? this["assignee"] as string : null;
        set => this["assignee"] = value;
    }
    
    /// <summary>
    /// Установить срок выполнения
    /// </summary>
    [JsonProperty("dueDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? DueDate
    {
        get => ContainsKey("dueDate") ? this["dueDate"] as DateTime? : null;
        set => this["dueDate"] = value;
    }
    
    /// <summary>
    /// Установить спринт
    /// </summary>
    [JsonProperty("sprint", NullValueHandling = NullValueHandling.Ignore)]
    public SprintReference Sprint
    {
        get => ContainsKey("sprint") ? this["sprint"] as SprintReference : null;
        set => this["sprint"] = value;
    }
}