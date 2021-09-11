using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Webapi_dotnet5.Data
{
    public class DbSeeder
    {
        public static void Seeder(IApplicationBuilder builder)
        {
            using(var scope = builder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

                if (!dbContext.Books.Any())
                {
                    dbContext.Books.AddRange(new Models.Book {
                        Title = "The gods must be crazy",
                        Description = "This is a sample description",
                        Author = "Mille Smith",
                        CoverUrl = "http://exple.com",
                        DateAdded = DateTime.Now,
                        DateRead = DateTime.Now,
                        Rate = 3,
                        IsRead = true,
                        Genre = "Drama"
                    },
                    new Models.Book
                    {
                        Title = "Revenge on eagle Island",
                        Description = "Another sample desctiption",
                        Author = "Mileage",
                        CoverUrl = "http://exple.com",
                        DateAdded = DateTime.Now,
                        IsRead = false,
                        Genre = "Drama"
                    }) ;

                    dbContext.SaveChanges();
                }


            }
        }
    }
}
