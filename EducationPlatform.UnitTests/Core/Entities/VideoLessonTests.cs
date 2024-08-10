using EducationPlatform.Application.Commands.VideoLessonCommands;
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
    public class VideoLessonTests
    {
        [Fact]
        public async void VideoLessonExists_Executed_UpdateVideoLesson()
        {
            // Arrange
            var videoLesson = new VideoLesson(1, "Videoaula teste", "Testando", "www.link.com", 60, 1);
            var name = "Nome atualizado";
            var description = "Descrição atualizada";

            var videoLessonRepositoryMock = Substitute.For<IVideoLessonRepository>();
            videoLessonRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(videoLesson);

            var updateVideoLessonCommand = new UpdateVideoLessonCommand(name, description);
            var updateVideoLessonCommandHandler = new UpdateVideoLessonCommandHandler(videoLessonRepositoryMock);

            // Act
            await updateVideoLessonCommandHandler.Handle(updateVideoLessonCommand, new CancellationToken());

            // Assert
            Assert.Equal(name, videoLesson.Name);
            Assert.Equal(description, videoLesson.Description);
            Assert.NotNull(videoLesson.UpdatedAt);
            await videoLessonRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await videoLessonRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void VideoLessonExists_Executed_DeleteVideoLesson()
        {
            // Arrange
            var videoLesson = new VideoLesson(1, "Videoaula teste", "Testando", "www.link.com", 60, 1);

            var videoLessonRepositoryMock = Substitute.For<IVideoLessonRepository>();
            videoLessonRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(videoLesson);

            var deleteVideoLessonCommand = new DeleteVideoLessonCommand();
            var deleteVideoLessonCommandHandler = new DeleteVideoLessonCommandHandler(videoLessonRepositoryMock);

            // Act
            await deleteVideoLessonCommandHandler.Handle(deleteVideoLessonCommand, new CancellationToken());

            // Assert
            Assert.False(videoLesson.Active);
            Assert.NotNull(videoLesson.InactivatedAt);
            await videoLessonRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await videoLessonRepositoryMock.Received(1).SaveAsync();
        }
    }
}
