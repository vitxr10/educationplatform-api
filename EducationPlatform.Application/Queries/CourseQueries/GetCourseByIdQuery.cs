﻿using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.CourseQueries
{
    public class GetCourseByIdQuery : IRequest<ServiceResult<CourseDetailsViewModel>>
    {
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
