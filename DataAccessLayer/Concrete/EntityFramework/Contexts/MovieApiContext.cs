using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.EntityFramework.Contexts;

public class MovieApiContext : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;Encrypt=false;");
  }

  public DbSet<Movie> Movies { get; set; }
}
