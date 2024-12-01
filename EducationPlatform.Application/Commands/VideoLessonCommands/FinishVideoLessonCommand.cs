using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class FinishVideoLessonCommand : IRequest<ServiceResult>
    {
        public int VideoLessonId { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int? Nota { get; set; }
    }
}
