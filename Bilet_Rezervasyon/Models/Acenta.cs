using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Acenta
    {
        [Key]
        public int AcentaId { get; set; }
        public string AcentaAd { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public DateTime ? Kurulus_Tarihi { get; set; }
        virtual public List<Sefer>? Sefers { get; set; }

    }
}
