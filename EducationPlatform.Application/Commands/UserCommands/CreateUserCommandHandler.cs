using AutoMapper;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Enums;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.UserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository, IAuthService authService, IMapper mapper)
        {
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            user.Role = "Student";
            user.Password = _authService.EncryptPassword(user.Password);

            var id = await _userRepository.CreateAsync(user);

            var userSubscription = new UserSubscription
                (
                    user.Id,
                    request.SubscriptionId,
                    SubscriptionStatusEnum.Pending,
                    DateTime.Now,
                    DateTime.Now.AddDays(365)
                );

            await _userSubscriptionRepository.CreateAsync(userSubscription);

            return id;
        }
    }
}
