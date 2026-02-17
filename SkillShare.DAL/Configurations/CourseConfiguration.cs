using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.DAL.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Description).IsRequired();
        builder.Property(c => c.Price).HasDefaultValue(0.00m).IsRequired();

        // ParentId для иерархии курсов (nullable)
        builder.Property<long?>("ParentId").IsRequired(false);

        // Автор/владелец курса
        builder.Property<long>("UserId").IsRequired();

        builder.HasIndex("ParentId");

        builder.HasOne(c => c.Author)
               .WithMany(u => u.Courses)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasMany(c => c.Lessons)
               .WithOne(l => l.Course)
               .HasForeignKey(l => l.CourseId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
