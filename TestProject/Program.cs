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
                var items = await new Api("")
                    .Books.GetBestSellersListHistory(author: "Steve Monroe");
                //Console.WriteLine(items.ToJson());
                foreach (var item in items)
                {
                    Console.WriteLine(item.ToJson());
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}