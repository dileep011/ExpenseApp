using ExpenseApp.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Dal
{
    public class ExpenseAppDbContext : DbContext
    {
        public ExpenseAppDbContext(DbContextOptions<ExpenseAppDbContext> options):base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ExpenseDetails> ExpenseDetails { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().ToTable("City");
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ExpenseDetails> entityTypeBuilder = modelBuilder.Entity<ExpenseDetails>().ToTable("ExpenseDetails").HasNoKey();
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<UserDetails>().ToTable("UserDetails");
        }
    }

}
