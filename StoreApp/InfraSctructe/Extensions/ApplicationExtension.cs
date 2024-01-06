using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.InfraSctructe.Extensions;
using StoreApp.InfraSctructe;
using System;
using System.Linq;
using Repositories;

namespace StoreApp.InfraSctructe.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                RepositoryContext context = serviceScope.ServiceProvider.GetRequiredService<RepositoryContext>();

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }

        public static void ConfigureLocalization(this IApplicationBuilder app)  // para birimi sembolü desteği için
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // UserManager
                UserManager<IdentityUser> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // RoleManager
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                IdentityUser user = await userManager.FindByNameAsync(adminUser);
                if (user is null)
                {
                    user = new IdentityUser()
                    {
                        Email = "berfingoksen24@gmail.com",
                        PhoneNumber = "5432266993",
                        UserName = adminUser,
                    };

                    var result = await userManager.CreateAsync(user, adminPassword);

                    if (!result.Succeeded)
                        throw new Exception("Admin user could not be created.");

                    var roleResult = await userManager.AddToRolesAsync(user,
                        roleManager.Roles.Select(r => r.Name).ToList()
                    );

                    if (!roleResult.Succeeded)
                        throw new Exception("System has problems with role definition for admin.");
                }
            }
        }
    }
}
