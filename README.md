# NYTimes.NET
A .NET Core SDK for NYTimes APIs.
Model classes generated using [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator).

# Usage
```
try
{
    var items = await new Api("<YOUR-API-KEY-HERE>")
        .TopStories.GetArticlesBySection("food");
    foreach (var item in items)
    {
        Console.WriteLine(item.ToJson());
    }
}
catch (ApiException aex)
{
    Console.WriteLine(aex.Message); 
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
```

# Contributing
- Sign up to [NY Times Developer Portal](https://developer.nytimes.com/apis) and create an application to obtain an API Key
- Fork and clone this repo and code away!