﻿using EducationPlatform.Infrastructure.DTOs;
using MediaToolkit.Model;
using MediaToolkit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using VimeoDotNet;
using VimeoDotNet.Net;
using EducationPlatform.Infrastructure.Services.Interfaces;

namespace EducationPlatform.Infrastructure.Services.Implementations
{
    public class VideoLessonService : IVideoLessonService
    {
        private readonly IConfiguration _configuration;
        private readonly string _accessToken;
        private readonly VimeoClient _vimeoClient;
        public VideoLessonService(IConfiguration configuration)
        {
            _configuration = configuration;
            _accessToken = _configuration["Services:VimeoConfigurations:AccessToken"];
            _vimeoClient = new VimeoClient(_accessToken);
        }

        public async Task<VimeoVideoDTO> GetVideoInfo(string videoUrl)
        {
            var videoId = ExtractVideoId(videoUrl);
            if (string.IsNullOrEmpty(videoId))
            {
                throw new Exception("Video ID não pôde ser extraído do link fornecido.");
            }

            try
            {
                var video = await _vimeoClient.GetVideoAsync(long.Parse(videoId));
                var vimeoVideoDTO = new VimeoVideoDTO(video.Id, video.Link, video.Duration);

                return vimeoVideoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter informações do vídeo: {ex.Message}");
            }
        }

        public string ExtractVideoId(string url)
        {
            // Extraindo o ID do vídeo do URL
            var uri = new Uri(url);
            var segments = uri.Segments;
            return segments.Length > 1 ? segments[1].TrimEnd('/') : string.Empty;
        }

        public async Task<VimeoVideoDTO> UploadVideo(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("Nenhum arquivo enviado.");
            }

            try
            {
                using var fileStream = file.OpenReadStream();
                var video = await _vimeoClient.UploadEntireFileAsync(new BinaryContent(fileStream, file.FileName));

                var videoDuration = await GetVideoDuration(file);
                var vimeoVideoDTO = new VimeoVideoDTO(video.ClipId, video.ClipUri, videoDuration);

                return vimeoVideoDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetVideoDuration(IFormFile videoFile)
        {
            var tempFilePath = Path.GetTempFileName();
            await using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            var inputFile = new MediaFile { Filename = tempFilePath };
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
            }

            File.Delete(tempFilePath);

            return (int)inputFile.Metadata.Duration.TotalSeconds;
        }
    }
}
