using EducationPlatform.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record UserViewModel(
        int Id,
        string FullName,
        string Document,
        string Email,
        string Phone,
        bool Active,
        UserSubscriptionDTO UserSubscriptionDTO
    );
}
