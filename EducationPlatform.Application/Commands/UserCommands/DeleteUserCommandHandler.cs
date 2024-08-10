using EducationPlatform.Application.Common;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.UserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ServiceResult>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
                return ServiceResult.Error("Usuário não encontrado.", ErrorTypeEnum.NotFound);

            user.Delete();
            user.UserSubscription.Disable();

            await _userRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
