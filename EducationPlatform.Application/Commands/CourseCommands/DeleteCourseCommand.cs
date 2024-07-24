using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class DeleteCourseCommand : IRequest<ServiceResult>
    {
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
