using EducationPlatform.Infrastructure.DTOs;

namespace EducationPlatform.Infrastructure.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> CreatePayment(CreatePaymentDTO payment);
        Task<string> CreateCustomer(CreateCustomerDTO customer);
    }
}