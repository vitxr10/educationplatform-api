using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class Subscription
    {
        public Subscription()
        {
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInDays { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public List<Course> Courses { get; set; }

        public void Delete()
        {
            Active = false;
            InactivatedAt = DateTime.Now;
        }

        public void Update(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
