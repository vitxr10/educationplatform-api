using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class Course
    {
        public Course()
        {
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }

        public void Update(string name, string description, string cover)
        {
            Name = name;
            Description = description;
            Cover = cover;
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Active = false;
            InactivatedAt = DateTime.Now;
        }
    }
}
