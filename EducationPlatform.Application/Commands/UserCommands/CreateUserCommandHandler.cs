using AutoMapper;
using EducationPlatform.Application.Common;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<int>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserSubscriptionRepository _userSubscriptionRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository, IUserSubscriptionRepository userSubscriptionRepository, IAuthService authService, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
            _userSubscriptionRepository = userSubscriptionRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<ServiceResult<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

            if (subscription == null)
                return ServiceResult<int>.Error("Assinatura não encontrada", ErrorTypeEnum.NotFound);

            var user = _mapper.Map<User>(request);

            user.Role = "Student";
            user.Password = _authService.EncryptPassword(user.Password);

            var id = await _userRepository.CreateAsync(user);

            var userSubscription = new UserSubscription
                (
                    id,
                    request.SubscriptionId,
                    SubscriptionStatusEnum.Pending,
                    DateTime.Now,
                    DateTime.Now.AddDays(365)
                );

            await _userSubscriptionRepository.CreateAsync(userSubscription);

            return ServiceResult<int>.Success(id);
        }
    }
}
