using Microsoft.AspNetCore.Identity;

namespace DRRestaurant.Infrastructure.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } 
        public string LastName { get; set; }
        public string? ImagePath { get; set; } = null!;
    }
}
