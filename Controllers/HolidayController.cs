
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Web_Api.Domain.Models;

namespace WEB_API_1_Paskaita.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HolidayController(IHttpClientFactory _httpClientFactory) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable <Holiday>> GetHolidaysByCountryAddYear(string country, int year)
        {
            using var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync($"https://calendarific.com/api/v2/holidays?api_key=ZMQEc0GRyiZbUrbIexwVqtAVnpQ0s3G2&country={country}&year={year}");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                Root? respons = JsonConvert.DeserializeObject<Root>(content);
                return respons.response.holidays;
            }
            else
            {
                throw new ArgumentException("The Holiday has not been found");
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Country>>GetSuportedCounties()
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync("https://calendarific.com/api/v2/countries?api_key=ZMQEc0GRyiZbUrbIexwVqtAVnpQ0s3G2");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                Root? respons = JsonConvert.DeserializeObject<Root>(content);
                return respons.response.countries;
            }
            else
            {
                throw new ArgumentException("The Country has not been found");
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Language>> GetSuportedLanguages()
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync("https://calendarific.com/api/v2/languages?api_key=ZMQEc0GRyiZbUrbIexwVqtAVnpQ0s3G2");
            if (resp.IsSuccessStatusCode)
            {
                var content = await resp.Content.ReadAsStringAsync();
                Root? respons = JsonConvert.DeserializeObject<Root>(content);
                return respons.response.languages;
            }
            else
            {
                throw new ArgumentException("The Country has not been found");
            }
        }
    }
}
