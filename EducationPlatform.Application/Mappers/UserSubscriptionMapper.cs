using AutoMapper;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class UserSubscriptionMapper : Profile
    {
        public UserSubscriptionMapper()
        {
            CreateMap<UserSubscription, UserSubscriptionDTO>();
        }
    }
}
