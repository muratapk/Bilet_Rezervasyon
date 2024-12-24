using Microsoft.EntityFrameworkCore;
using Bilet_Rezervasyon.Models;
namespace Bilet_Rezervasyon.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Bilet> Bilets { get; set; }
        public DbSet<Gise> Gises { get; set; }
        public DbSet<KartBilgi> KartBilgi { get; set; }
        public DbSet<Musteri> Musteri { get; set; } 
        public DbSet<Odeme> Odeme { get; set; } 
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Rezervasyon>Rezervasyons { get; set; } 
        public DbSet<Sefer> Sefers { get; set; }
        public DbSet<Site> Site { get; set; }   
        public DbSet<Bilet_Rezervasyon.Models.Acenta> Acenta { get; set; } = default!;
    }
}
