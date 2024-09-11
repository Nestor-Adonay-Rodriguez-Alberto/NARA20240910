using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NARA20240910.Models.EN;

namespace NARA20240910.Models.DAL
{
    public class DBContext : DbContext 
    {
        // Constructor
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        // Tablas en DB:
        public DbSet<ProductNARA> ProductsNARA { get; set; }
    }
}
