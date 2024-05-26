using Kladionica.Models;
using Microsoft.EntityFrameworkCore;

namespace Kladionica.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Oklada> Okladas { get; set; }
        public DbSet<Utakmica> Utakmicas { get; set; }
    }
}
