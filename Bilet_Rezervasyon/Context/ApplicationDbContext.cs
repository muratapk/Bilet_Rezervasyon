using Microsoft.EntityFrameworkCore;

namespace Bilet_Rezervasyon.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
        }
    }
}
