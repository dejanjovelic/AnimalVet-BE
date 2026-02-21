using Exam.App.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Exam.App.Infrastructure.Database;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleEditor = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var context = serviceProvider.GetRequiredService<AppDbContext>();

        string[] roles = { "Veterinarian", "Assistant", "Owner" };
        foreach (var role in roles)
        {
            if (!await roleEditor.RoleExistsAsync(role))
            {
                await roleEditor.CreateAsync(new IdentityRole(role));
            }
        }

        //Veterinarians
        var veterinarians = new List<ApplicationUser>
        {
            new ApplicationUser
            {
                UserName = "john",
                Email = "john.doe@example.com",
                Name = "John",
                Surname = "Doe",
                EmailConfirmed = true
            },
            new ApplicationUser
            {
                UserName = "jane",
                Email = "jane.doe@example.com",
                Name = "Jane",
                Surname = "Doe",
                EmailConfirmed = true
            },
                new ApplicationUser
            {
                UserName = "simon",
                Email = "simon.doe@example.com",
                Name = "Simon",
                Surname = "Doe",
                EmailConfirmed = true
            }
        };


        foreach (var user in veterinarians)
        {
            var existingUser = await userManager.FindByNameAsync(user.UserName);
            if (existingUser == null)
            {
                await userManager.CreateAsync(user, $"{user.Name}123!");
                existingUser = user;
            }

            if (!await userManager.IsInRoleAsync(existingUser, "Veterinarian"))
            {
                await userManager.AddToRoleAsync(existingUser, "Veterinarian");
            }

            if (!context.Veterinarians.Any(v => v.UserId == existingUser.Id)) 
            {
                Veterinarian veterinarian = new Veterinarian
                {
                    UserId = existingUser.Id
                };
                context.Veterinarians.Add(veterinarian);
                await context.SaveChangesAsync();
            }
        }

        //ASSISTANT

        var assistants = new List<ApplicationUser>
        {
            new ApplicationUser
        {
            UserName = "simona",
            Email = "simona.backster@example.com",
            Name = "Simona",
            Surname = "Backster",
            EmailConfirmed = true
        },

            new ApplicationUser
        {
            UserName = "maria",
            Email = "maria.smith@example.com",
            Name = "Maria",
            Surname = "Smith",
            EmailConfirmed = true
        },
            new ApplicationUser
        {
            UserName = "anaMarie",
            Email = "anaMarie.smith@example.com",
            Name = "AnaMarie",
            Surname = "Smith",
            EmailConfirmed = true
        }
        };

        foreach (var user in assistants)
        {
            var existingUser = await userManager.FindByNameAsync(user.UserName!);
            if (existingUser == null)
            {
                await userManager.CreateAsync(user, $"{user.Name}123!");
                existingUser = user;
            }

            if (!await userManager.IsInRoleAsync(existingUser, "Assistant"))
            {
                await userManager.AddToRoleAsync(existingUser, "Assistant");
            }

            if (!context.Assistants.Any(a => a.UserId == existingUser.Id)) 
            {
                Assistant assistant = new Assistant
                {
                    UserId =existingUser.Id
                };
                context.Assistants.Add(assistant);
                await context.SaveChangesAsync();
            }

            
        }

        //  OWNERS

        var owners = new List<ApplicationUser>
        {
            new ApplicationUser {
            UserName = "janny",
            Email = "janny.adams@example.com",
            Name = "Janny",
            Surname = "Adams",
            EmailConfirmed = true
            },

            new ApplicationUser
        {
            UserName = "jerry",
            Email = "jerry.adams@example.com",
            Name = "Jerry",
            Surname = "Adams",
            EmailConfirmed = true
        },

            new ApplicationUser
        {
            UserName = "adam",
            Email = "adam.vedder@example.com",
            Name = "Adam",
            Surname = "Vedder",
            EmailConfirmed = true
        }

        };

        foreach (var user in owners)
        {
            var existingUser = await userManager.FindByNameAsync(user.UserName!);
            if (existingUser == null)
            {
                await userManager.CreateAsync(user, $"{user.Name}123!");
                existingUser = user;    
            }

            if (!await userManager.IsInRoleAsync(existingUser, "Owner"))
            {
                await userManager.AddToRoleAsync(existingUser, "Owner");
            }

            if (!context.Owners.Any(o => o.UserId == existingUser.Id)) 
            {
                Owner owner = new Owner
                {
                  UserId = existingUser.Id
                };
                context.Owners.Add(owner);
                await context.SaveChangesAsync();
            }
            
        }


    }
}