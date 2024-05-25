
using EducationPlatform.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace EducationPlatform.Application.Services
{
    public interface IVideoLessonService
    {
        Task<int> GetVideoDuration(IFormFile file);
        Task<VimeoVideoDTO> UploadVideo(IFormFile file);
    }
}