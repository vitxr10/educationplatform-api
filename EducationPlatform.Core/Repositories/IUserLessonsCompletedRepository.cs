using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Repositories
{
    public interface IUserLessonsCompletedRepository
    {
        Task CreateAsync(UserLessonsCompleted userLessonsCompleted);
    }
}
