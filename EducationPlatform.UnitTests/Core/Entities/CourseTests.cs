using EducationPlatform.Application.Commands.CourseCommands;
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
    public class CourseTests
    {
        [Fact]
        public async void CourseExists_Executed_UpdateCourse()
        {
            // Arrange
            var course = new Course(1, "Curso Teste", "Testando", "www.cover.com");

            var name = "Nome atualizado";
            var description = "Descrição atualizada";
            var cover = "www.updatedcover.com";

            var courseRepositoryMock = Substitute.For<ICourseRepository>();
            courseRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(course);

            var updateCourseCommand = new UpdateCourseCommand(name, description, cover);
            var updateCourseCommandHandler = new UpdateCourseCommandHandler(courseRepositoryMock);

            // Act
            await updateCourseCommandHandler.Handle(updateCourseCommand, new CancellationToken());

            // Assert
            Assert.Equal(name, course.Name);
            Assert.Equal(description, course.Description);
            Assert.Equal(cover, course.Cover);
            Assert.NotNull(course.UpdatedAt);
            await courseRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await courseRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void CourseExists_Executed_DeleteCourse()
        {
            // Arrange
            var course = new Course(1, "Curso Teste", "Testando", "www.cover.com");

            var courseRepositoryMock = Substitute.For<ICourseRepository>();
            courseRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(course);

            var deleteCourseCommand = new DeleteCourseCommand();
            var deleteCourseCommandHandler = new DeleteCourseCommandHandler(courseRepositoryMock);

            // Act
            await deleteCourseCommandHandler.Handle(deleteCourseCommand, new CancellationToken());

            // Assert
            Assert.False(course.Active);
            Assert.NotNull(course.InactivatedAt);
            await courseRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await courseRepositoryMock.Received(1).SaveAsync();
        }
    }
}
