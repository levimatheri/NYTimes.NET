using NYTimes.NET.Clients;
using NYTimes.NET.Clients.Archive;
using NYTimes.NET.Clients.ArticleSearch;
using NYTimes.NET.Clients.Books;
using NYTimes.NET.Clients.MostPopular;

namespace NYTimes.NET
{
    public class Api
    {
        private readonly Configuration _configuration = new();

        public Api(string apiKey)
        {
            _configuration.AddApiKey(Constants.ApiKeyPrefix, apiKey);
        }

        public IArchiveClient Archives
        {
            get
            {
                _configuration.BasePath = Constants.ArchiveApi.BaseUrl;
                return new ArchiveClient(_configuration);
            }
        }

        public IArticleSearchClient ArticleSearch
        {
            get
            {
                _configuration.BasePath = Constants.ArticleSearchApi.BaseUrl;
                return new ArticleSearchClient(_configuration);
            }
        }
        
        public IBooksClient Books
        {
            get
            {
                _configuration.BasePath = Constants.BooksApi.BaseUrl;
                return new BooksClient(_configuration);
            }
        }

        public IMostPopularClient MostPopular
        {
            get
            {
                _configuration.BasePath = Constants.MostPopularApi.BaseUrl;
                return new MostPopularClient(_configuration);
            }
        }
    }
}