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
                var articlesList = await new Api("BEEWoNIsn2C6RB0AXSSDUlzQd8qgvG66")
                    .ArticleSearch.SearchArticles(q: "elections");
                foreach (var item in articlesList)
                {
                    Console.WriteLine(item);
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}