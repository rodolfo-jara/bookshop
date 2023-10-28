using static Bookshop.Web.Utility.SD;

namespace Bookshop.Web.Models
{
    public class RequestDto
    {
        //TIPO DE RESPUESTA
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
