using AutoMapper;
using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDetailsViewModel>()
                .ForMember(uv => uv.UserSubscriptionDTO, options => options
                .MapFrom(u => new UserSubscriptionDTO(u.UserSubscription.SubscriptionId, u.UserSubscription.Status,
                u.UserSubscription.StartDate, u.UserSubscription.ExpirationDate)));

            CreateMap<User, UserViewModel>()
                .ForMember(uv => uv.UserSubscriptionDTO, options => options
                .MapFrom(u => new UserSubscriptionDTO(u.UserSubscription.SubscriptionId, u.UserSubscription.Status,
                u.UserSubscription.StartDate, u.UserSubscription.ExpirationDate)));
        }
    }
}
