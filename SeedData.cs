using System;
using System.Linq;
using ASPNETMVCCoreTest.Data;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
//using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCoreTest
{
    public class SeedConfigurationDbData
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding database...");

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                EnsureSeedData(context);
            }

            Console.WriteLine("Done seeding database.");
            Console.WriteLine();
        }

        private static void EnsureSeedData(ConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                Console.WriteLine("Clients being populated");
                foreach (var client in Config.GetClients().ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Clients already populated");
            }

            if (!context.IdentityResources.Any())
            {
                Console.WriteLine("IdentityResources being populated");
                foreach (var resource in Config.GetIdentityResources().ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("IdentityResources already populated");
            }

            if (!context.ApiResources.Any())
            {
                Console.WriteLine("ApiResources being populated");
                foreach (var resource in Config.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ApiResources already populated");
            }
        }
    }

    //public class SeedSystemData
    //{
    //    public static void EnsureSeedData(IServiceProvider serviceProvider)
    //    {
    //        using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
    //        {
    //            scope.ServiceProvider.GetRequiredService<NutriMostContext>().Database.Migrate();

    //            var context = scope.ServiceProvider.GetRequiredService<NutriMostContext>();
    //            context.Database.Migrate();
    //            EnsureSeedData(context);
    //        }
    //    }

    //    private static void EnsureSeedData(NutriMostContext context)
    //    {

    //    }
    //}

    public class SeedAspNetSystemAccount
    {
        public static void EnsureSeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
                EnsureSeedData(context);

            }
        }

        private static void EnsureSeedData(ApplicationDbContext context)
        {

        }
    }
}
