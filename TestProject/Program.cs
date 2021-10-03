using System;
using System.Threading.Tasks;
using NYTimes.NET;

namespace TestProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var articles = await new API("apiKey")
                .Archives.GetAllMonthArticles(2019, 1);
            foreach (var item in articles)
            {
                Console.WriteLine(item.ToJson());
            }
        }
    }
}