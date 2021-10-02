using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NYTimes.NET.Models.Archive;
using ApiClientConfiguration = NYTimes.NET.Clients.Configuration;
namespace NYTimes.NET.Clients.Archive
{
    public class ArchiveClient : IArchiveClient
    {
        public ArchiveClient()
        {
            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new ApiClientConfiguration { BasePath = GetBasePath() }
            );
            
            this.Client = new ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ApiClientConfiguration.DefaultExceptionFactory;
        }

        public ArchiveClient(Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            
            this.Configuration = ApiClientConfiguration.MergeConfigurations(
                GlobalConfiguration.Instance,
                new ApiClientConfiguration { BasePath = GetBasePath() }
            );
        }
        
        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public IAsynchronousClient AsynchronousClient { get; set; }
        
        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ISynchronousClient Client { get; set; }
        
        public IReadableConfiguration Configuration { get; set; }
        public string GetBasePath()
        {
            return Constants.ArchiveApi.BaseUrl;
        }

        public ExceptionFactory ExceptionFactory { get; set; }
        public Task<IReadOnlyList<Article>> GetAllMonthArticles(int year, int month, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}