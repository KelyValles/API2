using Newtonsoft.Json;

namespace API2.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7121/"); // Establece la dirección base
        }

        public async Task<string> ConsultarApi(string url)
        {
            try
            {
                // Realiza la solicitud GET a la API utilizando la URL proporcionada
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lee la respuesta como string
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la API: " + ex.Message);
            }
        }
    }
}
