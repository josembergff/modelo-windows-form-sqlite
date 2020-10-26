

using Microsoft.EntityFrameworkCore;

namespace WindowsFormsApp1.Models
{
    public class SqLiteContexto : DbContext
    {
        public SqLiteContexto(DbContextOptions<SqLiteContexto> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
            
        }
    }
}
