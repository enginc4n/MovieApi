using Entities.Concrete;

namespace Business.Abstract;

public interface ITmdbService
{
  Task<MoviePage> GetMoviesByPageAsync(int page);
}
