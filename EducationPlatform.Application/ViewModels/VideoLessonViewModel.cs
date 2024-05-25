using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public class VideoLessonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoLink { get; set; }
        public int DurationInSeconds { get; set; }
    }
}
