using AutoMapper;
using EducationPlatform.Application.Commands.SubscriptionCommands;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class SubscriptionMapper : Profile
    {
        public SubscriptionMapper()
        {
            CreateMap<CreateSubscriptionCommand, Subscription>();
            CreateMap<Subscription, SubscriptionDetailsViewModel>();
            CreateMap<Subscription, SubscriptionViewModel>();
        }
    }
}
