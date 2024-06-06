using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.ModuleCommands
{
    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand>
    {
        private readonly IModuleRepository _moduleRepository;
        public UpdateModuleCommandHandler(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await _moduleRepository.GetByIdAsync(request.Id);

            if (module == null) throw new NotFoundException("Módulo não encontrado.");

            module.Update(request.Name, request.Description);

            await _moduleRepository.SaveAsync();
        }
    }
}
