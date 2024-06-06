using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.DTOs
{
    public class VimeoVideoDTO
    {
        public VimeoVideoDTO(long? clipId, string clipUri, int duration)
        {
            ClipId = clipId;
            ClipUri = clipUri;
            Duration = duration;
        }

        public long? ClipId { get; set; }
        public string ClipUri { get; set; }
        public int Duration { get; set; }
    }
}
