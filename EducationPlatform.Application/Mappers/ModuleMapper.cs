using AutoMapper;
using EducationPlatform.Application.Commands.ModuleCommands;
using EducationPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Mappers
{
    public class ModuleMapper : Profile
    {
        public ModuleMapper()
        {
            CreateMap<CreateModuleCommand, Module>();
        }
    }
}
