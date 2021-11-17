using NYTimes.NET.Models;

namespace NYTimes.NET.Tests.Mocks
{
    public class RSSFeedsMocks
    {
        public static Rss GetMockRssFeedData()
        {
            return new Rss
            {
                Channel = new Channel
                {
                    Title = "Test channel"
                }
            };
        }

        public static string GetMockRssFeedDataAsXml()
        {
            return $"<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                $"<rss><channel></channel></rss>";
        }
    }
}
