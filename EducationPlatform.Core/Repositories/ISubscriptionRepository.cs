using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllAsync(string? stringQuery);
        Task<Subscription> GetByIdAsync(int id);
        Task<int> CreateAsync(Subscription subscription);
        Task SaveAsync();
    }
}
