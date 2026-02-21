using Exam.App.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exam.App.Infrastructure.Database;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }
    public DbSet<Assistant> Assistants { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<AnimalSpecies> AnimalSpecies { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed AnimalSpecies

        modelBuilder.Entity<AnimalSpecies>(e =>
        {
            e.HasData(
              new AnimalSpecies { Id = 1, Name = "Pas" },
              new AnimalSpecies { Id = 2, Name = "Mačka" },
              new AnimalSpecies { Id = 3, Name = "Papagaj" },
              new AnimalSpecies { Id = 4, Name = "Kornjača" },
              new AnimalSpecies { Id = 5, Name = "Zec" },
              new AnimalSpecies { Id = 6, Name = "Hrčak" }
            );
        });

        // Seed Patients
        modelBuilder.Entity<Patient>(e =>
        {
            e.HasData(
              new Patient { Id = 1, Name = "Micka", AnimalSpeciesId = 2, DateOfBirth = DateTime.UtcNow.AddYears(-2), OwnerId = 1 },
              new Patient { Id = 2, Name = "Crni", AnimalSpeciesId = 1, DateOfBirth = DateTime.UtcNow.AddMonths(-4), OwnerId = 1 },
              new Patient { Id = 3, Name = "Rasa", AnimalSpeciesId = 3, DateOfBirth = DateTime.UtcNow.AddYears(-1), OwnerId = 2 }
              );

            e.HasOne(p => p.Owner)
            .WithMany()
            .HasForeignKey(p => p.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Owner>()
            .HasOne(o=>o.User)
            .WithOne()
            .HasForeignKey<Owner>(o=>o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
