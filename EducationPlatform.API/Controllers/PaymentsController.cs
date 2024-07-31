using EducationPlatform.Application.Commands.CourseCommands;
using EducationPlatform.Infrastructure.DTOs;
using EducationPlatform.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePaymentDTO payment)
        {
            try
            {
                var invoiceUrl = await _paymentService.CreatePayment(payment);

                return Ok(invoiceUrl);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível gerar o pagamento." + ex);
            }
        }

        [HttpPost("customer")]
        public async Task<IActionResult> Post(CreateCustomerDTO customer)
        {
            try
            {
                var invoiceUrl = await _paymentService.CreateCustomer(customer);

                return Ok(invoiceUrl);
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível gerar o cliente." + ex);
            }
        }
    }
}
