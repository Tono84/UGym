using BackEnd.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data;

public class UGymContext : IdentityDbContext<UGymUser>
{
    public UGymContext(DbContextOptions<UGymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmergencyContact> EmergencyContacts { get; set; } = null!;
    public virtual DbSet<Qrcode> Qrcodes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    private static void SeedRoles(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData
            (
            new IdentityRole() { Name = "Administrator", ConcurrencyStamp = "1", NormalizedName = "Administrador" },
            new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "Socio" },
            new IdentityRole() { Name = "Nutritionist", ConcurrencyStamp = "3", NormalizedName = "Nutricionista" },
            new IdentityRole() { Name = "Receptionist", ConcurrencyStamp = "4", NormalizedName = "Recepcionista" },
            new IdentityRole() { Name = "Therapist", ConcurrencyStamp = "5", NormalizedName = "Terapeuta" },
            new IdentityRole() { Name = "Coach", ConcurrencyStamp = "6", NormalizedName = "Entrenador" }
            );
    }
}