using EducationPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.DTOs
{
    public class UserSubscriptionDTO
    {
        public UserSubscriptionDTO()
        {
            
        }
        public UserSubscriptionDTO(int subscriptionId, SubscriptionStatusEnum status, DateTime startDate, DateTime expirationDate)
        {
            SubscriptionId = subscriptionId;
            Status = status;
            StartDate = startDate;
            ExpirationDate = expirationDate;
        }

        public int SubscriptionId { get; set; }
        public SubscriptionStatusEnum Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
