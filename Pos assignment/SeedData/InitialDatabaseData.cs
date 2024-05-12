using infrastructurre.DBContext;
using infrastructurre.DTO;
using infrastructurre.Entities;
using Microsoft.AspNetCore.Identity;

namespace Pos_assignment.SeedData
{
    public static class InitialDatabaseData
    {

        static string roleId = Guid.NewGuid().ToString();
        public static async Task SeedUsers(AppDbContext context, UserManager<User> userManager)
        {
            if (!context.Users.Any(a => a.UserName == "admin"))
            {
                User user = new User
                {
                    UserName = "admin",
                    Email = "roodlesnepal@gmail.com"
                };

                IdentityResult result = await userManager.CreateAsync(user, "Pass@word1");

                await context.SaveChangesAsync();
            }
            await context.SaveChangesAsync();
        }

        


        public static IHost SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<User>>();

                SeedUsers(context, userManager).GetAwaiter().GetResult();
               
            }
            return host;
        }
    }
}


