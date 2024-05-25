using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EducationPlatform.Application.DTOs
{
    public class VimeoVideoDTO
    {
        public VimeoVideoDTO(long? clipId, string clipUri, int duration)
        {
            ClipId = clipId;
            ClipUri = clipUri;
            Duration = duration;
        }

        //[JsonPropertyName("link")]
        public long? ClipId { get; set; }
        public string ClipUri { get; set; }
        public int Duration { get; set; }
    }

    //public class VimeoVideoDataDTO
    //{
    //    public VimeoVideoDTO[] Data { get; set; }
    //}
}
