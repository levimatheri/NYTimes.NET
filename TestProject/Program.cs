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
                    .Books.GetBookReviews(isbn: 9780307476463);
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