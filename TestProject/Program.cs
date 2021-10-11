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
                    .Books.GetBestSellersListByDate("2016-01-03", "Trade Fiction Paperback");
                Console.WriteLine(items.ToJson());
                // foreach (var item in items)
                // {
                //     Console.WriteLine(item.ToJson());
                // }
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}