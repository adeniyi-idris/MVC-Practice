using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MVC;Trusted_Connection=True;ConnectRetryCount=0");
        }

    }
}
