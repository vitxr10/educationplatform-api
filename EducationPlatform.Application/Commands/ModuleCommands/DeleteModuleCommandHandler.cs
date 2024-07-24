using EducationPlatform.Application.Common;
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
    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand, ServiceResult>
    {
        private readonly IModuleRepository _moduleRepository;
        public DeleteModuleCommandHandler(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<ServiceResult> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
        {
            var module = await _moduleRepository.GetByIdAsync(request.Id);

            if (module == null) 
                return ServiceResult.Error("Módulo não encontrado.", ErrorTypeEnum.NotFound);

            module.Delete();

            await _moduleRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
