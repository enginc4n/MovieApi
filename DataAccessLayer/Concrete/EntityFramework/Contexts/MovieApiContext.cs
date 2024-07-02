using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts;

public class MovieApiContext : DbContext
{
  public DbSet<Movie> Movies { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=localhost;Database=MovieDatabase;Trusted_Connection=True;Encrypt=false;");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>()
      .Ignore(m => m.GenreIdsList)
      .Property(m => m.GenreIds)
      .HasColumnName("GenreIds");
  }
}
