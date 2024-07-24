using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class DeleteVideoLessonCommand : IRequest<ServiceResult>
    {
        public DeleteVideoLessonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
