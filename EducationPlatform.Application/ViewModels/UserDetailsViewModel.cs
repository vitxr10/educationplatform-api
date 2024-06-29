using EducationPlatform.Application.DTOs;
using EducationPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record UserDetailsViewModel(
        int Id,
        string FullName,
        string Document,
        string Email,
        string Phone,
        DateTime BirthDate,
        bool Active,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? InactivatedAt,
        UserSubscriptionDTO UserSubscriptionDTO
    );
}
