using Newtonsoft.Json;

namespace YandexTracker.Client.Api;

public class UpdateIssueRequest
{
    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    public string Summary { get; set; }

    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public IssueType Type { get; set; }

    [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
    public IssuePriority Priority { get; set; }

    [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
    public ParentIssue Parent { get; set; }

    [JsonProperty("sprint", NullValueHandling = NullValueHandling.Ignore)]
    public List<SprintReference> Sprint { get; set; }

    [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
    public FollowersUpdate Followers { get; set; }

    [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
    public TagsUpdate Tags { get; set; }

    [JsonProperty("project", NullValueHandling = NullValueHandling.Ignore)]
    public ProjectUpdate Project { get; set; }

    /// <summary>
    /// Дедлайн
    /// </summary>
    [JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? Deadline { get; set; }
}

// Вспомогательные классы
public class IssueType
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("key")] public string Key { get; set; }
}

public class IssuePriority
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("key")] public string Key { get; set; }
}

public class ParentIssue
{
    [JsonProperty("key")] public string Key { get; set; }
}

public class SprintReference
{
    [JsonProperty("id")] public string Id { get; set; }
}

public class FollowersUpdate
{
    [JsonProperty("add")] public List<string> Add { get; set; }

    [JsonProperty("remove", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Remove { get; set; }
}

public class TagsUpdate
{
    [JsonProperty("add")] public List<string> Add { get; set; }

    [JsonProperty("remove")] public List<string> Remove { get; set; }
}

public class ProjectUpdate
{
    [JsonProperty("primary", NullValueHandling = NullValueHandling.Ignore)]
    public long? Primary { get; set; }

    [JsonProperty("secondary", NullValueHandling = NullValueHandling.Ignore)]
    public SecondaryProjectsUpdate Secondary { get; set; }
}

public class SecondaryProjectsUpdate
{
    [JsonProperty("add")] public List<long> Add { get; set; }

    [JsonProperty("remove", NullValueHandling = NullValueHandling.Ignore)]
    public List<long> Remove { get; set; }
}