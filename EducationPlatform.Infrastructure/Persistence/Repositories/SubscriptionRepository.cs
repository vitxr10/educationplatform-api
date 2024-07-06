using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoDotNet.Models;

namespace EducationPlatform.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly EducationPlatformDbContext _dbContext;
        public SubscriptionRepository(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Subscription subscription)
        {
            await _dbContext.Subscriptions.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();

            return subscription.Id;
        }

        public async Task<List<Subscription>> GetAllAsync(string? queryString)
        {
            return await _dbContext.Subscriptions.ToListAsync();
        }

        public async Task<List<Subscription>> GetAllByUserIdAsync(int userId)
        {
            return await _dbContext.UsersSubscriptions
                .Where(us => us.UserId == userId)
                .Include(us => us.Subscription)
                .Select(us => us.Subscription)
                .ToListAsync();
        }

        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _dbContext.Subscriptions.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
