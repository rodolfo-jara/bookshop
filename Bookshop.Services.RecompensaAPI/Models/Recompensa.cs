namespace Bookshop.Services.RecompensaAPI.Models
{
    public class Recompensa
    {
        public int Id { get; set; }
        public string UserId { get; set;}
        public DateTime recompensasFecha { get; set; }
        public int recompensasActividad { get; set; }
        public int OrderId { get; set; }
    }
}
