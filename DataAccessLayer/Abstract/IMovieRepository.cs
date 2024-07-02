using Core.DataAccessLayer.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Abstract;

public interface IMovieRepository : IEntityRepostitory<Movie>
{
  Task AddOrUpdateMovieAsync(Movie movie);
}
