namespace YandexTracker.Client.Models;

/// <summary>
/// Задача
/// </summary>
public class Issue
{
    /// <summary>
    /// Адрес ресурса API, который содержит информацию о задаче.
    /// </summary>
    public string Self { get; set; }

    /// <summary>
    /// Идентификатор задачи.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Ключ задачи.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Версия задачи. Каждое изменение параметров задачи увеличивает номер версии.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string Summary { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public DateTimeOffset? StatusStartTime { get; set; }

    /// <summary>
    /// Объект с информацией о последнем сотруднике, изменявшим задачу.
    /// </summary>
    public User UpdatedBy { get; set; }

    /// <summary>
    /// Деадлайн
    /// </summary>
    public DateTimeOffset? Deadline { get; set; }

    public StatusType StatusType { get; set; }

    /// <summary>
    /// Объект с информацией о проекте задачи.	
    /// </summary>
    public Project Project { get; set; }

    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string Description { get; set; }

    public Board[] Boards { get; set; }

    /// <summary>
    /// Объект с информацией о типе задачи.
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// Объект с информацией о приоритете.
    /// </summary>
    public Priority Priority { get; set; }

    public User PreviousStatusLastAssignee { get; set; }

    /// <summary>
    /// Дата и время создания задачи.	
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Объект с информацией о создателе задачи.	
    /// </summary>
    public User CreatedBy { get; set; }

    public int CommentWithoutExternalMessageCount { get; set; }
    public string Unique { get; set; }

    /// <summary>
    /// Количество голосов за задачу.	
    /// </summary>
    public int Votes { get; set; }

    public int CommentWithExternalMessageCount { get; set; }

    /// <summary>
    /// Объект с информацией об исполнителе задачи.	
    /// </summary>
    public User Assignee { get; set; }

    /// <summary>
    /// Объект с информацией об очереди задачи.	
    /// </summary>
    public Queue Queue { get; set; }

    /// <summary>
    /// Дата и время последнего обновления задачи.	
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Объект с информацией о статусе задачи.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Объект с информацией о предыдущем статусе задачи.	
    /// </summary>
    public Status PreviousStatus { get; set; }

    /// <summary>
    /// Родительская задача
    /// </summary>
    public Parent Parent { get; set; }

    /// <summary>
    /// Избранная задача
    /// </summary>
    public bool Favorite { get; set; }
    
    /// <summary>
    /// Чек-лист
    /// </summary>
    public List<CheckListItem> ChecklistItems { get; set; }
}