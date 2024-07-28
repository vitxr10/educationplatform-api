using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<decimal> GetUserCourseProgressAsync(int userId, int courseId)
        {
            var videoLessonsCount = await _dbContext.VideoLessons
                .Where(vl => vl.Active == true && vl.Module.CourseId == courseId && vl.Module.Active == true)
                .CountAsync();

            var userLessonsCompletedCount = await _dbContext.UserLessonsCompleted
                .Where(ulc => ulc.UserId == userId && ulc.VideoLesson.Active == true && ulc.VideoLesson.Module.CourseId == courseId && ulc.VideoLesson.Module.Active == true)
                .CountAsync();

            decimal userCourseProgressPercentage = 0;
            if (videoLessonsCount > 0)
            {
                userCourseProgressPercentage = (decimal)userLessonsCompletedCount / videoLessonsCount;
            }

            return Math.Round(userCourseProgressPercentage, 2);
        }
    }
}
