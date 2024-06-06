using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface IModuleRepository
    {
        Task<List<Module>> GetAllAsync(string? stringQuery);
        Task<Module> GetByIdAsync(int id);
        Task<int> CreateAsync(Module module);
        Task SaveAsync();
    }
}
