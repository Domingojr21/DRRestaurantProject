
using DRRestaurant.Core.Application.Enums;
using DRRestaurant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace DRRestaurant.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Waiter.ToString()));
        }
    }
}
