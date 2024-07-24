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
    public class GetAllVideoLessonsQuery : IRequest<ServiceResult<List<VideoLessonViewModel>>>
    {
    }
}
