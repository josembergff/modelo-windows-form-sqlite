using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WindowsFormsApp1.Models
{
    public class SqLiteContextFactory : IDesignTimeDbContextFactory<SqLiteContexto>
    {
        public SqLiteContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqLiteContexto>();
            optionsBuilder.UseSqlite("Data Source=SqLiteContexto.db");

            return new SqLiteContexto(optionsBuilder.Options);
        }
    }
}
