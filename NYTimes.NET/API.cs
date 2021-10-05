using NYTimes.NET.Clients;
using NYTimes.NET.Clients.Archive;
using NYTimes.NET.Clients.ArticleSearch;
using NYTimes.NET.Clients.Books;

namespace NYTimes.NET
{
    public class Api
    {
        private readonly Configuration _configuration = new();

        public Api(string apiKey)
        {
            _configuration.AddApiKey(Constants.ApiKeyPrefix, apiKey);
        }

        public ArchiveClient Archives
        {
            get
            {
                _configuration.BasePath = Constants.ArchiveApi.BaseUrl;
                return new ArchiveClient(_configuration);
            }
        }

        public ArticleSearchClient ArticleSearch
        {
            get
            {
                _configuration.BasePath = Constants.ArticleSearchApi.BaseUrl;
                return new ArticleSearchClient(_configuration);
            }
        }
        
        public BooksClient Books
        {
            get
            {
                _configuration.BasePath = Constants.BooksApi.BaseUrl;
                return new BooksClient(_configuration);
            }
        }
    }
}