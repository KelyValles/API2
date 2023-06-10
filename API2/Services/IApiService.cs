namespace API2.Services
{
    public interface IApiService
    {
        Task<string> ConsultarApi(string url);

    }
}
