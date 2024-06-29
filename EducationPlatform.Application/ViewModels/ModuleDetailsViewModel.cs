using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record ModuleDetailsViewModel(
        int Id,
        int CourseId,
        string Name,
        string Description,
        bool Active,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? InactivatedAt
    );
}
