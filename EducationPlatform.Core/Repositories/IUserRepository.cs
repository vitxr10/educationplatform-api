using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface IUserRepository 
    {
        Task<List<User>> GetAllAsync(string? stringQuery);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAndPasswordAsync(string email, string password);
        Task<int> CreateAsync(User user);
        Task SaveAsync();
    }
}
