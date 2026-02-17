using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.DAL.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id).ValueGeneratedOnAdd();
        builder.Property(l => l.Name).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Content).IsRequired();

        builder.HasIndex(l => l.CourseId);

        builder.HasOne(l => l.Course)
               .WithMany(c => c.Lessons)
               .HasForeignKey(l => l.CourseId)
               .OnDelete(DeleteBehavior.Cascade);


        builder.HasMany(c => c.Questions)
               .WithOne(q => q.Lesson)
               .HasForeignKey(q => q.LessonId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
