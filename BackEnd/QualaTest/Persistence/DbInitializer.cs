using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using System;
using System.Linq;

namespace Persistence
{
    /// <summary>
    /// DB Initializer 
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Initializer
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any currencies.
                if (context.Currencies.Any())
                {
                    return;   // DB has been seeded
                }

                var currencies = new Currency[]
                {
                    new Currency{Name="US Dollar", Symbol='$', Id=Guid.NewGuid()},
                    new Currency{Name="Euro",Symbol='€', Id=Guid.NewGuid()},
                    new Currency{Name="Yen", Symbol= '¥', Id=Guid.NewGuid()},
                    new Currency{Name="Libra", Symbol='£', Id=Guid.NewGuid()},
                    new Currency{Name="Franco", Symbol='₣', Id=Guid.NewGuid()},
                    new Currency{Name="Ca Dollar",Symbol='$', Id=Guid.NewGuid()}
                        };
                foreach (Currency s in currencies)
                {
                    context.Currencies.Add(s);
                }
                context.SaveChanges();

               
                context.SaveChanges();

            }
        }
    }
}