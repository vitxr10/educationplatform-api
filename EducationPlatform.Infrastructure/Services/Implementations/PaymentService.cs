using EducationPlatform.Infrastructure.DTOs;
using EducationPlatform.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EducationPlatform.Infrastructure.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey = _configuration["Asaas:Key"];
        }

        public async Task<string> CreateCustomer(CreateCustomerDTO customerDTO)
        {
            string url = "https://sandbox.asaas.com/api/v3/customers";

            var customerData = new
            {
                name = customerDTO.Name,
                cpfCnpj = customerDTO.CpfCnpj,
                email = customerDTO.Email,
                mobilePhone = customerDTO.MobilePhone
            };

            string jsonPaymentData = JsonSerializer.Serialize(customerData);

            using (HttpClient client = new())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "access_token", _apiKey },
                        { "User-Agent", "EducationPlatform" },
                    },
                    Content = new StringContent(jsonPaymentData)
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadFromJsonAsync<CreateCustomerResponseDTO>();
                    return body.Id;
                }
            }
        }

        public async Task<string> CreatePayment(CreatePaymentDTO paymentDTO)
        {
            string url = "https://sandbox.asaas.com/api/v3/payments";

            var paymentData = new
            {
                customer = paymentDTO.Customer,
                billingType = paymentDTO.BillingType,
                dueDate = paymentDTO.DueDate,
                value = paymentDTO.Value,
                description = paymentDTO.Description
            };

            string jsonPaymentData = JsonSerializer.Serialize(paymentData);

            using (HttpClient client = new())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(url),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "access_token", _apiKey },
                        { "User-Agent", "EducationPlatform" },
                    },
                    Content = new StringContent(jsonPaymentData)
                    {
                        Headers =
                        {
                            ContentType = new MediaTypeHeaderValue("application/json")
                        }
                    }
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadFromJsonAsync<CreatePaymentResponseDTO>();
                    return body.InvoiceUrl;
                }
            }
        }
    }
}
