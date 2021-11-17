using NYTimes.NET;
using NYTimes.NET.Clients;
using System;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var item = await new NYTimesApi("BEEWoNIsn2C6RB0AXSSDUlzQd8qgvG66")
                    .RSSFeedsClient.GetChannelArticles("Africa");
                
                //foreach (var item in items)
                //{
                //    Console.WriteLine(item.ToJson());
                //}
            }
            catch (ApiException aex)
            {
                Console.WriteLine(aex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
