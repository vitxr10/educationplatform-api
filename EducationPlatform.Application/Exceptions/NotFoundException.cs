using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resourse) : base($"{resourse} não encontrado.")
        {

        }
    }
}
