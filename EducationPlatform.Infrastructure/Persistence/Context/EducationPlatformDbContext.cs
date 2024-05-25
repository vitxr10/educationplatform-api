using EducationPlatform.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence.Context
{
    public class EducationPlatformDbContext : DbContext
    {
        public EducationPlatformDbContext(DbContextOptions<EducationPlatformDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<VideoLesson> VideoLessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
