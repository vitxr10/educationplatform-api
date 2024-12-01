using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.VideoLessonQueries
{
    public class GetVideoLessonsByModuleIdQuery : IRequest<ServiceResult<List<VideoLessonDetailsViewModel>>>
    {
        public GetVideoLessonsByModuleIdQuery(int moduleId)
        {
            ModuleId = moduleId;
        }

        public int ModuleId { get; set;}
    }
}
