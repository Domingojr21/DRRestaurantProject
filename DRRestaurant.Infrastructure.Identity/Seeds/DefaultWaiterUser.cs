
using DRRestaurant.Core.Application.Enums;
using DRRestaurant.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace DRRestaurant.Infrastructure.Identity.Seeds
{
    public static class DefaultWaiterUser
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser defaultUser = new();
            defaultUser.UserName = "waiteruser";
            defaultUser.Email = "waiteruser@email.com";
            defaultUser.Name = "El Basic";
            defaultUser.LastName = "24";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if(userManager.Users.All(u=> u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Waiter.ToString());
                }
            }
         
        }
    }
}
