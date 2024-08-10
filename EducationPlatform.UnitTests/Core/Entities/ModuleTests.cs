using EducationPlatform.Application.Commands.ModuleCommands;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.UnitTests.Core.Entities
{
    public class ModuleTests
    {
        [Fact]
        public async void ModuleExists_Executed_UpdateModule()
        {
            // Arrange
            var module = new Module(1, "Módulo teste", "Testando");
            var name = "Nome atualizado";
            var description = "Descrição atualizada";

            var moduleRepositoryMock = Substitute.For<IModuleRepository>();
            moduleRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(module);

            var updateModuleCommand = new UpdateModuleCommand(name, description);
            var updateModuleCommandHandler = new UpdateModuleCommandHandler(moduleRepositoryMock);

            // Act
            await updateModuleCommandHandler.Handle(updateModuleCommand, new CancellationToken());

            // Assert
            Assert.Equal(name, module.Name);
            Assert.Equal(description, module.Description);
            Assert.NotNull(module.UpdatedAt);
            await moduleRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await moduleRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void ModuleExists_Executed_DeleteModule()
        {
            // Arrange
            var module = new Module(1, "Módulo teste", "Testando");

            var moduleRepositoryMock = Substitute.For<IModuleRepository>();
            moduleRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(module);

            var deleteModuleCommand = new DeleteModuleCommand();
            var deleteModuleCommandHandler = new DeleteModuleCommandHandler(moduleRepositoryMock);

            // Act
            await deleteModuleCommandHandler.Handle(deleteModuleCommand, new CancellationToken());

            // Assert
            Assert.False(module.Active);
            Assert.NotNull(module.InactivatedAt);
            await moduleRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await moduleRepositoryMock.Received(1).SaveAsync();
        }
    }
}
