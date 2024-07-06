using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsByUserIdQuery : IRequest<List<SubscriptionViewModel>>
    {
        public GetAllSubscriptionsByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
