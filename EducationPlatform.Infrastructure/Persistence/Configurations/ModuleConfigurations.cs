using EducationPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence.Configurations
{
    public class ModuleConfigurations : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasMany(m => m.VideoLessons)
                .WithOne(v => v.Module)
                .HasForeignKey(v => v.ModuleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
