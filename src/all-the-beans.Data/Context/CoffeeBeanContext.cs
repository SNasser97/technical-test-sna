using all_the_beans.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace all_the_beans.Data.Context
{
    internal class CoffeeBeanContext : DbContext
    {
        public DbSet<CoffeeBean> CoffeeBean { get; set; }

        public CoffeeBeanContext(DbContextOptions<CoffeeBeanContext> options) : base(options) { }
    }
}
