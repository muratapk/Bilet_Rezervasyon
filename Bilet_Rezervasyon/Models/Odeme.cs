using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Odeme
    {
        [Key]
        public int? OdemeId { get; set; }    
        public int? MusteriId { get; set; }
        public int? BiletId { get; set; }

        virtual public Musteri? Musteri { get; set; }
        virtual public Bilet? Bilet { get; set; }

    }
}
