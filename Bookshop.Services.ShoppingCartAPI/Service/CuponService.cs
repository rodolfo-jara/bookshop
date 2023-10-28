using Bookshop.Services.ShoppingCartAPI.Models.Dto;
using Bookshop.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Bookshop.Services.ShoppingCartAPI.Service
{
    public class CuponService : ICuponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CuponService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }
        public async Task<CuponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Cupon");
            var response = await client.GetAsync($"/api/cupon/GetByCode/{couponCode}");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp != null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CuponDto>(Convert.ToString(resp.Result));
            }
            return new CuponDto();
        }


    }
}
