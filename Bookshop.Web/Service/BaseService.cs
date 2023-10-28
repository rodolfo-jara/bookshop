using Bookshop.Web.Models;
using Bookshop.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Bookshop.Web.Utility.SD;

namespace Bookshop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public  async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {

            try { 
            HttpClient client = _httpClientFactory.CreateClient("BookshopAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Acept", "application/json");
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }
                message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            { 
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? apiResponse = null;

            switch(requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);

            switch(apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not found"};
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Acceso Denegado" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "No autorizado" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Error Interno del Servidor" };

                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
              
            }
            }catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
               };
            return dto;
            }
        }
    }
}
