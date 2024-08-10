using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class Module
    {
        public Module()
        {
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public Module(int courseId, string name, string description)
        {
            CourseId = courseId;
            Name = name;
            Description = description;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public List<VideoLesson> VideoLessons { get; set; }
        public Course Course { get; set; }

        public void Delete()
        {
            Active = false;
            InactivatedAt = DateTime.Now;
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
            UpdatedAt = DateTime.Now;
        }
    }
}
