using Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "1st book Title",
                        Description = "1st Book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Comics",
                       
                        CoverUrl = "https.........",
                        DateAdded = DateTime.Now

                    },
                    new Models.Book()
                    {
                        Title = "2nd book Title",
                        Description = "2nd Book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-20),
                        Rate = 4,
                        Genre = "Biography",
                      
                        CoverUrl = "https.........",
                        DateAdded = DateTime.Now

                    }


                    );
                    context.SaveChanges();
                }

            }
        }
    }
}
