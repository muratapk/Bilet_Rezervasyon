using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriId { get; set; }


        [Required(ErrorMessage ="TC No Boş Bırakılamaz")]
        [StringLength(11,ErrorMessage ="TC.No 11 Karakter Olmaz Zorunda")]
        [Display(Name ="T.C. Kimlik Numarası")]
        public int ? TcNo { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string Cinsiyet { get; set; } = string.Empty;
        public DateTime ? Dogum_Tarihi { get; set; }
        public string Telefon { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public int ? Yas { get; set; }
        virtual public List<Rezervasyon> ?Rezervasyons { get; set; }
        //rezevasyon birden fazla rezervasyon yapabilir
        virtual public List<KartBilgi>? KartBilgi { get; set; }


    }
}
