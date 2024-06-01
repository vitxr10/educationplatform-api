using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
    }
}
