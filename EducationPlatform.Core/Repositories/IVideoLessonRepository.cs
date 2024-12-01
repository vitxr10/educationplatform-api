using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface IVideoLessonRepository
    {
        Task<List<VideoLesson>> GetAllAsync();
        Task<VideoLesson> GetByIdAsync(int id);
        Task<List<VideoLesson>> GetByModuleIdAsync(int id);
        Task<VideoLesson> GetByVimeoIdAsync(long id);
        Task<int> CreateAsync(VideoLesson videolesson);
        Task SaveAsync();
    }
}
