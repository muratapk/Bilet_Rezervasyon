using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Rezervasyon
    {

        [Key]
        public int RezervasyonId { get; set; }
        public int ? MusteriId { get; set; }
        public int? BiletId { get;set; }
        public string Bicim { get; set; } = string.Empty;
        public  int ? Sayisi { get; set; }
        public DateTime ? Tarih { get; set; }
        virtual public Musteri ? Musteri { get; set; }
        //birden fazla Müsteri Kaydı Girebilir
        virtual public Bilet ? Bilet { get; set; }

    }
}
