using Entity2.Data;
using Microsoft.EntityFrameworkCore;

namespace Entity2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<EventHubContext>()
                .UseSqlServer("Server=localhost;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;

            using (var context = new EventHubContext(options))
            {
                Console.WriteLine("Database Context Created Successfully!");
            }
        }
    }
}