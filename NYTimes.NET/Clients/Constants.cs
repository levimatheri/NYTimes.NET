﻿namespace NYTimes.NET.Clients
{
    public static class Constants
    {
        public const string ApiKeyPrefix = "api-key";
        public static class ArchiveApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/archive/v1";
        }
        
        public static class ArticleSearchApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/search/v2";
        }
    }
}