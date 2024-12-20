using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Bilet_Rezervasyon.Models
{
    public class Gise
    {
        [Key]
        public int GiseId {  get; set; }
        public String GiseAd { get; set; } = string.Empty; 
        virtual public List<Personel> ? Personels { get; set; }  

    }
}
