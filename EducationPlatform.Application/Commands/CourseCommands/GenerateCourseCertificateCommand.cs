using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class GenerateCourseCertificateCommand : IRequest<ServiceResult>
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
