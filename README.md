# NYTimes.NET
[![Build Status](https://levimatheri.visualstudio.com/NYTimes.NET/_apis/build/status/levimatheri.NYTimes.NET?branchName=main)](https://levimatheri.visualstudio.com/NYTimes.NET/_build/latest?definitionId=6&branchName=main)

A .NET Core SDK for NYTimes APIs.
Model classes generated using [OpenAPI Generator](https://github.com/OpenAPITools/openapi-generator).

# Installation
* [Install from NuGet Gallery](https://www.nuget.org/packages/NYTimes.Net/)

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
