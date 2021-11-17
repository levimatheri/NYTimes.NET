namespace NYTimes.NET.Clients
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
        
        public static class BooksApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/books/v3";
        }

        public static class MostPopularApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/mostpopular/v2";
        }

        public static class MovieReviewsApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/movies/v2";
        }

        public static class SemanticApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/semantic/v2/concept";
        }

        public static class TimesNewsWireApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/news/v3";
        }

        public static class TopStoriesApi
        {
            public const string BaseUrl = "https://api.nytimes.com/svc/topstories/v2";
        }

        public static class RSSFeedsApi
        {
            public const string BaseUrl = "https://api.nytimes.com/services/xml/rss/nyt";
        }

        public static class XmlNamespaces
        {
            public const string Atom = "http://www.w3.org/2005/Atom";
            public const string Dc = "http://purl.org/dc/elements/1.1/";
            public const string Media = "http://search.yahoo.com/mrss/";
            public const string Nyt = "http://www.nytimes.com/namespaces/rss/2.0";
        }
    }
}