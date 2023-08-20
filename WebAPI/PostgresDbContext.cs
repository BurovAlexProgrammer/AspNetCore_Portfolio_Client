using Microsoft.EntityFrameworkCore;
using WebDAL;

namespace WebAPI
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Department> Departments { get; set; }

        public PostgresDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=3000;Database=Portfolio;Username=postgres;Password=Freedom88");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API - higest priority
            builder.Entity<Guest>()
                .ToTable("WTF") //Table name
                .HasKey("Id"); //Primary key

            builder.Entity<Department>()
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("DepName");
        }
    }
}