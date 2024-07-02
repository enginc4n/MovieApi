using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IMovieService
{
  IDataResult<Movie?> GetById(int movieId);
  IDataResult<List<Movie>> GetList(int pageSize, int pageNumber);
  IResult Add(Movie movie);
  IResult Delete(Movie movie);
  IResult Update(Movie movie);
}
