using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.UserQueries
{
    public class GetUserCourseProgressQuery : IRequest<ServiceResult<decimal>>
    {
        public GetUserCourseProgressQuery(int userId, int courseId)
        {
            UserId = userId;
            CourseId = courseId;
        }

        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
