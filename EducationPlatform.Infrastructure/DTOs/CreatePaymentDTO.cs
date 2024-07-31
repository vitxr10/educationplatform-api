using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.DTOs
{
    public class CreatePaymentDTO
    {
        public string Customer { get; set; }
        public string BillingType { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
