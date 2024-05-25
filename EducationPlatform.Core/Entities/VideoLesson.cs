using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class VideoLesson
    {
        public VideoLesson(long? vimeoVideoId, string name, string description, string videoLink, int durationInSeconds)
        {
            VimeoVideoId = vimeoVideoId;
            Name = name;
            Description = description;
            VideoLink = videoLink;
            DurationInSeconds = durationInSeconds;
        }

        public int Id { get; set; }
        public long? VimeoVideoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public int DurationInSeconds { get; set; }
    }
}
