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

            builder.ToTable("UserLessonsCompleted");
        }
    }
}
