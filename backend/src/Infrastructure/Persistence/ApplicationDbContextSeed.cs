using UpworkAssignment.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace UpworkAssignment.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {

    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        await context.SaveChangesAsync();
    }
}
