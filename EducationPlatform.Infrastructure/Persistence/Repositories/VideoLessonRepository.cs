using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Persistence.Repositories
{
    public class VideoLessonRepository : IVideoLessonRepository
    {
        private readonly EducationPlatformDbContext _dbContext;
        public VideoLessonRepository(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(VideoLesson videolesson)
        {
            await _dbContext.VideoLessons.AddAsync(videolesson);
            await _dbContext.SaveChangesAsync();

            return videolesson.Id;
        }

        public async Task<List<VideoLesson>> GetAllAsync()
        {
            return await _dbContext.VideoLessons.ToListAsync();
        }

        public async Task<VideoLesson> GetByIdAsync(int id)
        {
            return await _dbContext.VideoLessons.SingleOrDefaultAsync(vl => vl.Id == id);
        }

        public async Task<VideoLesson> GetByVimeoIdAsync(long id)
        {
            return await _dbContext.VideoLessons.SingleOrDefaultAsync(vl => vl.VimeoVideoId == id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
