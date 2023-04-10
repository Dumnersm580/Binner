﻿using Binner.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Binner.Data.Configurations
{
    public class ProjectPartAssignmentConfiguration : IEntityTypeConfiguration<ProjectPartAssignment>
    {
        public void Configure(EntityTypeBuilder<ProjectPartAssignment> builder)
        {
            builder.HasOne(p => p.Project)
                .WithMany(b => b.ProjectPartAssignments)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Part)
                .WithMany(b => b.ProjectPartAssignments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.DateCreatedUtc)
                .HasDefaultValueSql("getutcdate()");
            builder.Property(p => p.DateModifiedUtc)
                .HasDefaultValueSql("getutcdate()");
        }
    }
}
