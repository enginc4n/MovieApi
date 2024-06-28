using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MovieManager : IMovieService
{
  private IMovieDal _movieDal;

  public MovieManager(IMovieDal movieDal)
  {
    _movieDal = movieDal;
  }

  public IDataResult<Movie> GetById(int movieId)
  {
    Movie movie;
    try
    {
      movie = _movieDal.Get(m => m.Id == movieId);
      return new SuccessDataResult<Movie>(movie);
    }
    catch (Exception e)
    {
      movie = new Movie();
      return new ErrorDataResult<Movie>(movie, ErrorMessages.MovieCouldNotFound + " Message: " + e);
    }
  }

  public IDataResult<List<Movie>> GetList()
  {
    List<Movie> movies;
    try
    {
      movies = _movieDal.GetList();
      return new SuccessDataResult<List<Movie>>(movies);
    }
    catch (Exception e)
    {
      movies = new List<Movie>();
      return new ErrorDataResult<List<Movie>>(movies, ErrorMessages.MovieCouldNotFound + " Message: " + e);
    }
  }

  public IDataResult<List<Movie>> GetByGenreIds(List<int> genreIds)
  {
    List<Movie> movies;
    try
    {
      movies = _movieDal.GetList(m => m.GenreIds.Any(genreId => genreIds.Contains(genreId)));
      return new SuccessDataResult<List<Movie>>(movies);
    }
    catch (Exception e)
    {
      movies = new List<Movie>();
      return new ErrorDataResult<List<Movie>>(movies, ErrorMessages.MovieCouldNotFound + " Message: " + e.Message);
    }
  }

  public IResult Add(Movie movie)
  {
    try
    {
      _movieDal.Add(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotAdded + " Message: " + e);
    }
  }

  public IResult Delete(Movie movie)
  {
    try
    {
      _movieDal.Delete(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotDeleted + " Message: " + e);
    }
  }

  public IResult Update(Movie product)
  {
    try
    {
      _movieDal.Update(product);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotUpdated + " Message: " + e);
    }
  }

  public IResult AddNoteToMovie(int movieId, string note)
  {
    try
    {
      Movie movie = _movieDal.Get(m => m.Id == movieId);
      movie.MovieNote = note;
      _movieDal.Update(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotUpdated + " Message: " + e);
    }
  }

  public IResult RateMovie(int movieId, double rating)
  {
    try
    {
      Movie movie = _movieDal.Get(m => m.Id == movieId);
      movie.VoteAverage += rating;
      _movieDal.Update(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotUpdated + " Message: " + e);
    }
  }
}
