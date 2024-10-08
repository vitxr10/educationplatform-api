﻿using EducationPlatform.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.ModuleCommands
{
    public class UpdateModuleCommand : IRequest<ServiceResult>
    {
        public UpdateModuleCommand(int id)
        {
            Id = id;
        }

        public UpdateModuleCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
