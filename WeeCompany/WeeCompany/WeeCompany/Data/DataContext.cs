using Microsoft.EntityFrameworkCore;
using WeeCompany.Shared.Entities;

namespace WeeCompany.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Tblpersonas> Tblpersonas { get; set; }
    }
}
