using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsQuery : IRequest<List<SubscriptionViewModel>>
    {
        public GetAllSubscriptionsQuery(string? stringQuery)
        {
            StringQuery = stringQuery;
        }

        public string? StringQuery { get; set; }
    }
}
