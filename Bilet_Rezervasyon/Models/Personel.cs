using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        public int ? TcNo { get;set; }
        public string  AdSoyad { get; set; }=string.Empty;
        public DateTime? Dogum_Tarihi { get; set; }
        public string SigortaNo { get; set; } = string.Empty;
        public int ? GiseId { set; get; }
        virtual public Gise ? Gise { get; set; }
        virtual public List<Bilet> ? Bilets { get; set; }
    }
}
