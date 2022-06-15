using FutureBank.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FutureBank.Services
{
    internal class InterestRateService : IInterestRateService
    {
        private readonly HttpClient _httpClient;
        public InterestRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<InterestRate> GetCurrentRate()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var response = await _httpClient.GetAsync("InterestRate/get-current-rate");

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<InterestRate>(await response.Content.ReadAsStreamAsync(), options);

            return null;
        }
    }
}
