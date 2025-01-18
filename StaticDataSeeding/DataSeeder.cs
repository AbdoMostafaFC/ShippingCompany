using Microsoft.AspNetCore.Identity;
using ShippingCompany.Models;

namespace ShippingCompany.StaticDataSeeding
{
    public static class DataSeeder
    {

        public static async Task SeedSuperAdmin(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string email = "abdo@admin.com";
            string password = "SuperAdmin123!";
            string roleName = "SuperAdmin";

         
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

          
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
             
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    
                    await userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    throw new Exception($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
            else
            {
                
                if (!await userManager.IsInRoleAsync(user, roleName))
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }



    }
}
