# Yandex Tracker Net Client

Не является полноценным клиентом для Yandex Tracker, методы будут добавляться по мере необходимости

Пример использования:
````csharp
var settings = new YandexApiSettings()
{
    XOrgId = "824255", // Идентификатор организации
    OAuth = "y0_A7qkixbXaAuasdfUEBO0nhAABfS6ptAIKDgVpQw5GdblNwr0A" // Токен
};

using (var client = new YandexTrackerClient(settings))
{
    var result = client.GetIssues(new GetIssueRequest()
    {
        filter = new Filter()
        {
            status = new Status()
            {
                id = "3"
            }
        }
    }, 500, 1).Result;
}
````