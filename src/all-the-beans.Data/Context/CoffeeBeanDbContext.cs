using all_the_beans.Data.Tables.CoffeeBeanTable;
using Microsoft.EntityFrameworkCore;

namespace all_the_beans.Data.Context
{
    public class CoffeeBeanDbContext : DbContext
    {
        private readonly List<KeyValuePair<string, bool>> nonNullableContraintColumns = new List<KeyValuePair<string, bool>>()
        {
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Name), true),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Colour), true),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Country), true),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Image), true),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Description), true),
        };

        private readonly List<KeyValuePair<string, bool>> indexColumns = new List<KeyValuePair<string, bool>>()
        {
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Name), false),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Index), true),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Colour), false),
            new KeyValuePair<string, bool>(nameof(CoffeeBeanTable.Country), false),
        };

        public DbSet<CoffeeBeanTable> CoffeeBean { get; set; }

        public CoffeeBeanDbContext(DbContextOptions<CoffeeBeanDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: on first run comment out ValueGeneratedOnAdd (auto increment)
            // Run another ef migration the second time to apply auto increment constraint
            // This is because MySQL does not support auto increment on a non-primary key column
            modelBuilder.Entity<CoffeeBeanTable>()
                .Property(b => b.Index)
                .ValueGeneratedOnAdd();

            // declare primary key
            modelBuilder.Entity<CoffeeBeanTable>()
                .HasKey(b => b.Id);

            // Add indexes for potential filtering/searching on columns: Name, Colour and Country
            // Otherwise filtering/searching will result in full table scans.
            // For small data set there is no impact but at scale will impact query performance
            this.SetColumnIndex(modelBuilder, this.indexColumns);

            // Set nullable contraint
            this.SetNullableColumnContraint(modelBuilder, this.nonNullableContraintColumns);
        }

        private void SetColumnIndex(ModelBuilder modelBuilder, IEnumerable<KeyValuePair<string,bool>> columns)
        {
            foreach(KeyValuePair<string, bool> column in columns)
            {
                var builder = modelBuilder.Entity<CoffeeBeanTable>()
                    .HasIndex(column.Key);

                if (column.Value)
                {
                    builder.IsUnique();
                }
            }
        }

        private void SetNullableColumnContraint(ModelBuilder modelBuilder, IEnumerable<KeyValuePair<string, bool>> columns)
        {
            foreach (KeyValuePair<string, bool> column in columns)
            {
                var builder = modelBuilder.Entity<CoffeeBeanTable>()
                    .Property(column.Key);

                if (column.Value)
                {
                    builder.IsRequired();
                }
            }
        }
    }
}
