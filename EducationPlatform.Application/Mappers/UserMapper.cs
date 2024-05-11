using AutoMapper;
using EducationPlatform.Application.Commands.UserCommands;
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
        }
    }
}
