using AutoMapper;
using EducationPlatform.Application.Commands.CourseCommands;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<Course, CourseDetailsViewModel>();
        }
    }
}
