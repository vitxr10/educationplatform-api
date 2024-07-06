using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.AuthCommands
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public AuthCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<AuthViewModel> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var encryptedPassword = _authService.EncryptPassword(request.Password);

            var user = await _userRepository.GetByEmailAndPasswordAsync(request.Email, encryptedPassword);

            if (user == null) 
                throw new Exception("Email e/ou senha incorretos.");

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new AuthViewModel(user.Email, user.Role, token);
        }
    }
}
