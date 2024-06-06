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
    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand>
    {
        private readonly IModuleRepository _moduleRepository;
        public DeleteModuleCommandHandler(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await _moduleRepository.GetByIdAsync(request.Id);

            if (module == null) throw new NotFoundException("Módulo não encontrado.");

            module.Delete();

            await _moduleRepository.SaveAsync();
        }
    }
}
