using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllAsync(string? stringQuery);
        Task<Course> GetByIdAsync(int id);
        Task<int> CreateAsync(Course course);
        Task SaveAsync();
    }
}
