using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class CreateLessonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Video { get; set; }
    }
}
