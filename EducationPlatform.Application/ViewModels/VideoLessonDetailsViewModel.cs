using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record VideoLessonDetailsViewModel(
        int Id,
        long? VimeoVideoId,
        string Name,
        string Description,
        string VideoLink,
        int DurationInSeconds,
        bool Active,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? InactivatedAt
    );
}
