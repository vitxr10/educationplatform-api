using EducationPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Core.Entities
{
    public class SubscriptionPayment
    {
        public int Id { get; set; }
        public int UserSubscriptionId { get; set; }
        public int ExternalPaymentId { get; set; }
        public DateTime ProcessingDate { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public string Message { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }

    }
}
