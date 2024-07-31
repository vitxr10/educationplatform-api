using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.DTOs
{
    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }
}
