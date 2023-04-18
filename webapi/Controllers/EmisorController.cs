using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmisorController : ControllerBase
    {
        private IHttpClientFactory _httpFactory;

        public EmisorController(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        [HttpGet]
        public async Task<dynamic> GetAll()
        {
            using var client = _httpFactory.CreateClient("Ecuasol");
            var response = await client.GetAsync("Varios/GetEmisor");

            if (response is null || !response.IsSuccessStatusCode)
            {
                return new List<EcuasolEmisor>();
            }

            var jsonContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject(jsonContent);
        }
    }
}
