﻿using AutoMapper;
using EducationPlatform.Application.DTOs;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.UserQueries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(request.StringQuery);

            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);

            return usersViewModel;
        }
    }
}
