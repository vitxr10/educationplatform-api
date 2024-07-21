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
    public class VideoLessonConfiguration : IEntityTypeConfiguration<VideoLesson>
    {
        public void Configure(EntityTypeBuilder<VideoLesson> builder)
        {
            builder.HasKey(vl => vl.Id);

            builder
                .HasMany(v => v.UserLessonsCompleted)
                .WithOne(ul => ul.VideoLesson)
                .HasForeignKey(ul => ul.VideoLessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
