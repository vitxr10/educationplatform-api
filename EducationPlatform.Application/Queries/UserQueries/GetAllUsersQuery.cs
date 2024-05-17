using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {
        public string? StringQuery { get; set; }
    }
}
