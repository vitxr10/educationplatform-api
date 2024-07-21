using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class VideoLesson
    {
        public VideoLesson(long? vimeoVideoId, string name, string description, string videoLink, int durationInSeconds, int moduleId)
        {
            VimeoVideoId = vimeoVideoId;
            Name = name;
            Description = description;
            VideoLink = videoLink;
            DurationInSeconds = durationInSeconds;
            ModuleId = moduleId;
        }

        public int Id { get; set; }
        public long? VimeoVideoId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public int DurationInSeconds { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public Module Module { get; set; }
        public List<UserLessonsCompleted> UserLessonsCompleted { get; set; }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Active = false;
            InactivatedAt = DateTime.Now;
        }
    }
}
