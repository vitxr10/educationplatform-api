using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class CreateVideoLessonCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //public IFormFile Video { get; set; }
        public string Video { get; set; }
        public int ModuleId { get; set; }
    }
}
