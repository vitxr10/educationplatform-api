using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record ModuleViewModel(
        int Id,
        int CourseId,
        string Name,
        string Description,
        bool Active
    );
}
