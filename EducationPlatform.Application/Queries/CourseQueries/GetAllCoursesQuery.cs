using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.CourseQueries
{
    public class GetAllCoursesQuery : IRequest<ServiceResult<List<CourseViewModel>>>
    {
        public GetAllCoursesQuery(string? stringQuery)
        {
            StringQuery = stringQuery;
        }

        public string? StringQuery { get; set; }
    }
}
