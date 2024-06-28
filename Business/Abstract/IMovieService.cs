using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract;

public interface IMovieService
{
  IDataResult<Movie> GetById(int movieId);
  IDataResult<List<Movie>> GetList();
  IDataResult<List<Movie>> GetByGenreIds(List<int> genreIds);
  IResult Add(Movie movie);
  IResult Delete(Movie movie);
  IResult Update(Movie movie);
  IResult AddNoteToMovie(int movieId, string note);
  IResult RateMovie(int movieId, double rating);
}
