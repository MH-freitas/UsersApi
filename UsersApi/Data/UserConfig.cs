using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersApi.Data
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(p => p.Role)
                .HasColumnName("role");

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("password");

        }
    }
}