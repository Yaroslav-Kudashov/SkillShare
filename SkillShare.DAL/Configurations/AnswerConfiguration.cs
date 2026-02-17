using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillShare.Domain.Entities;

namespace SkillShare.DAL.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(a => a.QuestionId).IsRequired();
        builder.Property(a => a.Value).IsRequired().HasMaxLength(2000);

        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers) 
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => a.QuestionId);
    }
}

