using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Sefer
    {
        [Key]
        public int SeferId { get; set; }
        public int AcentaId { get; set; }
        public string SeferAdi { get; set; } = string.Empty;  
        public int SeferKodu { get; set; }
        public string Gidis { get; set; } = string.Empty;
        public string Donus { get; set; } = string.Empty;
        public decimal ? Ucreti{get;set;} 
        public TimeOnly ? Saati { get; set; }
        virtual public Acenta ? Acenta { get; set; }
        //bir acentan bir sefer
        virtual public List<Bilet> ? Bilets { get; set; }


    }
}
