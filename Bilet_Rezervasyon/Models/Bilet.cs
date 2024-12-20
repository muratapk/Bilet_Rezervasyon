using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Bilet
    {
        [Key]
        public int BiletId { get; set; }
        public int ? MusteriId { get;set; }
        public int ? SeferId { get;set; }
        public int ?PersonelId { get;set; }
        public DateTime ? BTarih { get; set; }
        public TimeOnly BSaati { get; set; }
        public int ? PNR { get; set; }
        public int ? Koltuk { get; set; }
        public int ?BSayi { get; set; }
        public DateTime? Gecer_Sure{get;set;}
        public bool? BiletDurum {  get; set; }   
        virtual public List<Rezervasyon>? Rezervasons {  get; set; }  
        virtual public Sefer ? Sefer { get; set; }
        virtual public Personel ?Personel { get; set; }

    }
}
