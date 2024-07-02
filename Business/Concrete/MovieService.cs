using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class MovieService : IMovieService
{
  private IMovieRepository _movieRepository;

  public MovieService(IMovieRepository movieRepository)
  {
    _movieRepository = movieRepository;
  }

  public IDataResult<Movie?> GetById(int movieId)
  {
    Movie? movie;
    try
    {
      movie = _movieRepository.Get(m => m.Id == movieId);
      return new SuccessDataResult<Movie?>(movie);
    }
    catch (Exception e)
    {
      movie = new Movie();
      return new ErrorDataResult<Movie?>(movie, ErrorMessages.MovieCouldNotFound + e);
    }
  }

  public IDataResult<List<Movie>> GetList(int pageSize, int pageNumber)
  {
    List<Movie> movies;
    try
    {
      movies = _movieRepository.GetList(pageSize: pageSize, pageNumber: pageNumber);
      return new SuccessDataResult<List<Movie>>(movies);
    }
    catch (Exception e)
    {
      return new ErrorDataResult<List<Movie>>(null, ErrorMessages.MovieCouldNotFound + e);
    }
  }

  public IResult Add(Movie movie)
  {
    try
    {
      _movieRepository.Add(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotAdded + e);
    }
  }

  public IResult Delete(Movie movie)
  {
    try
    {
      _movieRepository.Delete(movie);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotDeleted + e);
    }
  }

  public IResult Update(Movie product)
  {
    try
    {
      _movieRepository.Update(product);
      return new SuccessResult();
    }
    catch (Exception e)
    {
      return new ErrorResult(ErrorMessages.MovieCouldNotUpdated + e);
    }
  }
}
