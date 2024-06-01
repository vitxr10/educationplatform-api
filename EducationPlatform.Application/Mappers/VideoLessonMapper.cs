using AutoMapper;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class VideoLessonMapper : Profile
    {
        public VideoLessonMapper()
        {
            CreateMap<VideoLesson, VideoLessonViewModel>();
            CreateMap<VideoLesson, VideoLessonDetailsViewModel>();
        }
    }
}
