using System;
using System.Linq;
using System.Threading.Tasks;
using NYTimes.NET;
using NYTimes.NET.Clients;

namespace TestProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var items = await new Api("BEEWoNIsn2C6RB0AXSSDUlzQd8qgvG66")
                    .MostPopular.GetMostEmailedArticlesByPeriod(1);
                //Console.WriteLine(items.ToJson());
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
        }
    }
}