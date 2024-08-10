using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class UpdateCourseCommand : IRequest<ServiceResult>
    {
        public UpdateCourseCommand()
        {
            
        }
        public UpdateCourseCommand(string name, string description, string cover)
        {
            Name = name;
            Description = description;
            Cover = cover;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
    }
}
