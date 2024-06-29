﻿using EducationPlatform.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.ModuleQueries
{
    public class GetModuleByIdQuery : IRequest<ModuleDetailsViewModel>
    {
        public GetModuleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
