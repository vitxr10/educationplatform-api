using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class User
    {
        public User()
        {
            Role = "student";
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public User(string fullName, string document, string email, string password, string phone, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            Email = email;
            Password = password;
            Phone = phone;
            BirthDate = birthDate;
            Active = true;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? InactivatedAt { get; set; }
        public UserSubscription UserSubscription { get; set; }
        public List<UserLessonsCompleted> UserLessonsCompleted { get; set; }

        public void Delete()
        {
            Active = false;
            InactivatedAt = DateTime.Now;
        }

        public void Update(string email, string phone)
        {
            Email = email;
            Phone = phone;
            UpdatedAt = DateTime.Now;
        }
    }
}
