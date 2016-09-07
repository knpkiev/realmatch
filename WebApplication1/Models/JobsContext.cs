using System.Data.Entity;

namespace WebApplication1.Models
{
    public class JobsContext : DbContext
    {
         public DbSet<LuJobTitle> LuJobTitles { get; set; }
         public DbSet<Jobs> Jobs { get; set; }
    }
}