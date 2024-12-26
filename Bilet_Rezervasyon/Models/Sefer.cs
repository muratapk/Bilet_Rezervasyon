using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Sefer
    {
        [Key]
        public int SeferId { get; set; }
        [DisplayName("ACENTA ADI")]
        [Required(ErrorMessage ="ACENTA ADI SEÇİNİZ:")]
        public int AcentaId { get; set; }
        [DisplayName("SEFER ADI")]
        [Required(ErrorMessage = "SEFER ADI GİRİNİZ:")]
        public string SeferAdi { get; set; } = string.Empty;
        [DisplayName("SEFER KODU")]
        [Required(ErrorMessage = "SEFER KODU GİRİNİZ:")]
        public int SeferKodu { get; set; }
        [DisplayName("GİDİŞ YERİ")]
        [Required(ErrorMessage = "GİDİŞ YERİ GİRİNİZ:")]
        public string Gidis { get; set; } = string.Empty;
        [DisplayName("DÖNÜŞ YERİ")]
        [Required(ErrorMessage = "DÖNÜŞ YERİ GİRİNİZ:")]
        public string Donus { get; set; } = string.Empty;
        [DisplayName("BİLET ÜCRETİ")]
        [Required(ErrorMessage = "BİLET ÜCRETİ GİRİNİZ:")]
        public decimal ? Ucreti{get;set;}
        [DisplayName("SEFER SAATİ")]
        [Required(ErrorMessage = "SEFER SAATİ GİRİNİZ:")]
        public TimeOnly ? Saati { get; set; }
        virtual public Acenta ? Acenta { get; set; }
        //bir acentan bir sefer
        virtual public List<Bilet> ? Bilets { get; set; }


    }
}
