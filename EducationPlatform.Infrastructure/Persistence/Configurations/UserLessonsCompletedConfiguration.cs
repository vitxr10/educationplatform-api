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
    public class UserLessonsCompletedConfiguration : IEntityTypeConfiguration<UserLessonsCompleted>
    {
        public void Configure(EntityTypeBuilder<UserLessonsCompleted> builder)
        {
            builder.HasKey(ul => ul.Id);

            builder
                .HasOne(ul => ul.User)
                .WithMany()
                .HasForeignKey(ul => ul.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ul => ul.VideoLesson)
                .WithMany()
                .HasForeignKey(ul => ul.VideoLessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
