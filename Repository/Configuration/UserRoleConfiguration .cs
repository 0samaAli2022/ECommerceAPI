using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "3c98a456-dce4-4e02-a9d2-7f3b9c8e9bfa", // Match the user Id
                RoleId = "6f4a2c3e-fd4d-42d3-ae56-3a2b6c6b3942" // Match the role Id for "User"
            },
            new IdentityUserRole<string>
            {
                UserId = "b65b1cd3-ef45-48a3-9acb-7d8e3e4672c4", // Match the user Id
                RoleId = "5b78b2a1-34e8-4a72-890e-81d92f739f3f" // Match the role Id for "User"
            }
        );
    }
}
