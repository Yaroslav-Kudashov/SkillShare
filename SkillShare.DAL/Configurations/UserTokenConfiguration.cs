using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.DAL.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("UserTokens");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.UserId).IsRequired();
        // Токен: храним хеш. Размер 512 покрывает Base64 SHA256/SHA512.
        builder.Property(t => t.RefreshToken).IsRequired().HasMaxLength(512);
        // Срок жизни токена
        builder.Property(t => t.RefreshTokenExpireTime)
               .IsRequired();

        builder.HasOne(t => t.User)
            .WithOne(u => u.UserToken)
            .HasForeignKey<UserToken>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // И уникальный индекс по UserId, чтобы гарантировать 1:1
        builder.HasIndex(t => t.UserId).IsUnique().HasDatabaseName("IX_UserTokens_UserId_Unique");

    }
}
