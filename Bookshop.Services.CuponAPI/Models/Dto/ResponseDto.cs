namespace Bookshop.Services.CuponAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Messaje { get; set; } = "";
    }
}
