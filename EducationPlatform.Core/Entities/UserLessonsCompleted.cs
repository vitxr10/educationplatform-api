using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class UserLessonsCompleted
    {
        public UserLessonsCompleted()
        {
            ConclusionDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoLessonId { get; set; }
        public int? Nota { get; set; }
        public DateTime ConclusionDate { get; set; }
        public User User { get; set; }
        public VideoLesson VideoLesson { get; set; }
    }
}
