using all_the_beans.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace all_the_beans.Data.Context
{
    public class CoffeeBeanDbContext : DbContext
    {
        public DbSet<CoffeeBean> CoffeeBean { get; set; }

        public CoffeeBeanDbContext(DbContextOptions<CoffeeBeanDbContext> options) : base(options) { }
    }
}
