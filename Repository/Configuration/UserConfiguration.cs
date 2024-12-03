using Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Create a password hasher instance
        var passwordHasher = new PasswordHasher<User>();

        // Seed user data
        var user = new User
        {
            Id = "3c98a456-dce4-4e02-a9d2-7f3b9c8e9bfa",
            FirstName = "Osama",
            LastName = "Ali",
            UserName = "OsamaAli",
            NormalizedUserName = "OSAMAALI",
            Email = "osama@gmail.com",
            NormalizedEmail = "OSAMA@GMAIL.COM",
            PhoneNumber = "589-679",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };

        // Hash the password
        user.PasswordHash = passwordHasher.HashPassword(user, "password123");

        var admin = new User
        {
            Id = "b65b1cd3-ef45-48a3-9acb-7d8e3e4672c4",
            FirstName = "Admin",
            LastName = "Admin",
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@gmail",
            NormalizedEmail = "ADMIN@GMAIL",
            PhoneNumber = "589-679",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };

        // Hash the password
        admin.PasswordHash = passwordHasher.HashPassword(admin, "password123");

        // Add the user data
        builder.HasData(admin);
        builder.HasData(user);
    }
}
