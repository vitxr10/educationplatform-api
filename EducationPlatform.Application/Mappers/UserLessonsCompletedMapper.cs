using AutoMapper;
using EducationPlatform.Application.Commands.VideoLessonCommands;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class UserLessonsCompletedMapper : Profile
    {
        public UserLessonsCompletedMapper()
        {
            CreateMap<FinishVideoLessonCommand, UserLessonsCompleted>();
        }
    }
}
