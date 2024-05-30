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
    public class UserSubscriptionRepository : IUserSubscriptionRepository
    {
        private readonly EducationPlatformDbContext _dbContext;
        public UserSubscriptionRepository(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(UserSubscription userSubscription)
        {
            await _dbContext.UsersSubscriptions.AddAsync(userSubscription);
            await _dbContext.SaveChangesAsync();
        }
    }
}
