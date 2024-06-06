using EducationPlatform.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;

namespace EducationPlatform.Infrastructure.Services.Interfaces
{
    public interface IVideoLessonService
    {
        Task<int> GetVideoDuration(IFormFile file);
        Task<VimeoVideoDTO> UploadVideo(IFormFile file);
    }
}