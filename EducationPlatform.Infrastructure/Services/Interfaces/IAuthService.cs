using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Services.Interfaces
{
    public interface IAuthService
    {
        string EncryptPassword(string password);
        string GenerateJwtToken(string email, string role);
    }
}
