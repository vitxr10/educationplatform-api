using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record CourseDetailsViewModel(
        int Id,
        int SubscriptionId,
        string Name,
        string Description,
        string Cover,
        bool Active,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? InactivatedAt
    );
}
