using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class KartBilgi
    {
        [Key]
        public int KartId { get; set; }  
        public int? MusteriId { get; set; }
        public string KartNo { get; set; } = string.Empty;
        public string KartSahibi { get; set; } = string.Empty;
        public string SonTarih { get; set; } = string.Empty;  
        public int ? Cvc { get; set; }
        virtual public Musteri ? Musteri { get; set; }

    }
}
