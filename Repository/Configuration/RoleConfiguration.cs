using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData
        (
            new IdentityRole
            {
                Id = "6f4a2c3e-fd4d-42d3-ae56-3a2b6c6b3942",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "5b78b2a1-34e8-4a72-890e-81d92f739f3f",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}
