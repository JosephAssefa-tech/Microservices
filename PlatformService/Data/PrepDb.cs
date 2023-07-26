using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("seeding data");
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "dot net",
                        Publisher = "Microsoft",
                        Cost = "Free"


                    },
                        new Platform()
                        {
                            Name = "SQL server",
                            Publisher = "Microsoft",
                            Cost = "Free"


                        },
                              new Platform()
                              {
                                  Name = "Kuberenetes",
                                  Publisher = "Microsoft",
                                  Cost = "Free"


                              });

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("we have already data");
            }

        }

    }
}
