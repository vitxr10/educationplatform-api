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
    public class ModuleRepository : IModuleRepository
    {
        private readonly EducationPlatformDbContext _dbContext;
        public ModuleRepository(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Module module)
        {
            await _dbContext.Modules.AddAsync(module);
            await _dbContext.SaveChangesAsync();

            return module.Id;
        }

        public async Task<List<Module>> GetAllAsync(string? queryString)
        {
            return await _dbContext.Modules.ToListAsync();
        }

        public async Task<Module> GetByIdAsync(int id)
        {
            return await _dbContext.Modules.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
