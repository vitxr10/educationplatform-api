using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Common
{
    public interface IPdfService
    {
        byte[] CreatePdf(string userFullName, string courseName);
    }
}
