using NYTimes.NET.Clients;
using NYTimes.NET.Clients.Archive;

namespace NYTimes.NET
{
    public class API
    {
        private readonly Configuration _configuration = new();

        public API(string apiKey)
        {
            _configuration.AddApiKey("api-key", apiKey);
        }
        
        public ArchiveClient Archives => new(_configuration);
    }
}