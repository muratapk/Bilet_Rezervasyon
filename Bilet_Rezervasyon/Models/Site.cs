using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Site
    {
        [Key]
        public int SiteId { get; set; }
        public string SiteAd { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
    }
}
