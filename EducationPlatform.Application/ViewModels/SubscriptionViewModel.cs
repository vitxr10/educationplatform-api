using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.ViewModels
{
    public record SubscriptionViewModel(
        int Id,
        string Name,
        int DurationInDays,
        bool Active
    );
}
