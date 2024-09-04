using Newtonsoft.Json;
using YandexTracker.Client.Api;

namespace YandexTracker.Client;

public class YandexTrackerClient : HttpClient
{
#pragma warning disable S1075
    private const string YandexUri = "https://api.tracker.yandex.net";
#pragma warning restore S1075

    private static readonly Lazy<JsonSerializerSettings> Settings = new(CreateSerializerSettings, true);

    private static JsonSerializerSettings CreateSerializerSettings()
    {
        var settings = new JsonSerializerSettings();
        UpdateJsonSerializerSettings(settings);
        return settings;
    }

    static void UpdateJsonSerializerSettings(JsonSerializerSettings settings)
    {
        settings.NullValueHandling = NullValueHandling.Ignore;
    }

    protected JsonSerializerSettings JsonSerializerSettings => Settings.Value;

    public YandexTrackerClient(string xOrgId, string oAuth)
    {
        BaseAddress = new Uri(YandexUri);
        DefaultRequestHeaders.Add("X-Org-ID", xOrgId);
        DefaultRequestHeaders.Add("Authorization", $"OAuth {oAuth}");
    }

    public YandexTrackerClient(YandexApiSettings settings)
    {
        BaseAddress = new Uri(YandexUri);
        if (!string.IsNullOrEmpty(settings.XOrgId))
            DefaultRequestHeaders.Add("X-Org-ID", settings.XOrgId);
        if (!string.IsNullOrEmpty(settings.XCloudOrgId))
            DefaultRequestHeaders.Add("X-Cloud-Org-ID", settings.XCloudOrgId);
        DefaultRequestHeaders.Add("Authorization", $"OAuth {settings.OAuth}");
    }

    public async Task<Issue> GetIssue(string id)
    {
        var response = await GetAsync($"/v2/issues/{id}");
        var status = (int)response.StatusCode;

        if (status == 200)
        {
            var objectResponse = await ReadObjectResponseAsync<Issue>(response, CancellationToken.None)
                .ConfigureAwait(false);
            if (objectResponse.Object == null)
            {
                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text,
                    null);
            }

            return objectResponse.Object;
        }

        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status,
            responseData, null);
    }

    public async Task<List<Issue>> GetIssues(GetIssueRequest request, int perPage = 50, int page = 1)
    {
        var json = JsonConvert.SerializeObject(request, Settings.Value)
                   ?? throw new ArgumentNullException(nameof(request));
        var content = new StringContent(json);
        var response = await PostAsync($"/v2/issues/_search?perPage={perPage}&page={page}", content);
        var status = (int)response.StatusCode;

        if (status == 200)
        {
            var objectResponse = await ReadObjectResponseAsync<List<Issue>>(response, CancellationToken.None)
                .ConfigureAwait(false);
            if (objectResponse.Object == null)
            {
                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text,
                    null);
            }

            return objectResponse.Object;
        }

        var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status,
            responseData, null);
    }

    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T responseObject, string responseText)
        {
            Object = responseObject;
            Text = responseText;
        }

        public T Object { get; }

        public string Text { get; }
    }

    protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(
        HttpResponseMessage? response,
        CancellationToken cancellationToken, bool readResponseAsString = false)
    {
        if (response == null)
        {
            return new ObjectResponseResult<T>(default(T), string.Empty);
        }

        try
        {
            if (readResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = JsonConvert.DeserializeObject<T>(responseText, JsonSerializerSettings);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, exception);
                }
            }
            else
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                using (var streamReader = new StreamReader(responseStream))
                using (var jsonTextReader = new JsonTextReader(streamReader))
                {
                    var serializer = JsonSerializer.Create(JsonSerializerSettings);
                    var typedBody = serializer.Deserialize<T>(jsonTextReader);
                    return new ObjectResponseResult<T>(typedBody, string.Empty);
                }
            }
        }
        catch (JsonException exception)
        {
            var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
            throw new ApiException(message, (int)response.StatusCode, string.Empty, exception);
        }
    }
}

public class GetIssueRequest
{
    public Filter? Filter { get; set; }
    public string Query { get; set; }
    public string Order { get; set; }
}

public class Filter
{
    public string Queue { get; set; }
    public string Assignee { get; set; }
    public Status Status { get; set; }
}