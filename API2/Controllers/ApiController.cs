using API2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IApiService _apiService;

        public ApiController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("{url}")]
        public async Task<IActionResult> Get(string url)
        {
            try
            {
                // Llama al método del servicio para realizar la consulta a la API
                var result = await _apiService.ConsultarApi("api/Car");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al consultar la API: {ex.Message}");
            }
        }
    }
}
