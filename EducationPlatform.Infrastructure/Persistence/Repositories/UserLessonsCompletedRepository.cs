using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence.Repositories
{
    public class UserLessonsCompletedRepository : IUserLessonsCompletedRepository
    {
        private readonly EducationPlatformDbContext _dbContext;
        public UserLessonsCompletedRepository(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(UserLessonsCompleted userLessonsCompleted)
        {
            await _dbContext.UserLessonsCompleted.AddAsync(userLessonsCompleted);
            await _dbContext.SaveChangesAsync();
        }
    }
}
