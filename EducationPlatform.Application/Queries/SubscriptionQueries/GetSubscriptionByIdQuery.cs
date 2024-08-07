﻿using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.SubscriptionQueries
{
    public class GetSubscriptionByIdQuery : IRequest<ServiceResult<SubscriptionDetailsViewModel>>
    {
        public GetSubscriptionByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
