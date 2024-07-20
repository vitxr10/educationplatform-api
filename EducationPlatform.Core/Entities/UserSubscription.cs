using EducationPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class UserSubscription
    {
        public UserSubscription()
        {
            
        }

        public UserSubscription(int userId, int subscriptionId, SubscriptionStatusEnum status, DateTime startDate, DateTime expirationDate)
        {
            UserId = userId;
            SubscriptionId = subscriptionId;
            Status = status;
            StartDate = startDate;
            ExpirationDate = expirationDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }
        public SubscriptionStatusEnum Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public User User { get; set; }
        public Subscription Subscription { get; set; }

        public void Disable()
        {
            Status = SubscriptionStatusEnum.Disabled;
        }
    }
}
