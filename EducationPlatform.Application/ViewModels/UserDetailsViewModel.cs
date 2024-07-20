using EducationPlatform.Application.DTOs;
using EducationPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record UserDetailsViewModel 
    {
        public UserDetailsViewModel()
        {
            
        }

        public int Id {  get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public UserSubscriptionDTO UserSubscriptionDTO { get; set; }
    }
}
