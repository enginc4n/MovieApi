using System.Linq.Expressions;
using Core.DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Newtonsoft.Json;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfMovieRepository : EfEntityRepositoryBase<Movie, MovieApiContext>, IMovieRepository
{
  public async Task AddOrUpdateMovieAsync(Movie movie)
  {
    using (MovieApiContext context = new())
    {
      Movie existingMovie = Get(m => m.Id == movie.Id);
      if (existingMovie == null)
      {
        Add(movie);
      }
      else
      {
        existingMovie.Adult = movie.Adult;
        existingMovie.BackdropPath = movie.BackdropPath;
        existingMovie.GenreIds = movie.GenreIds;
        existingMovie.OriginalLanguage = movie.OriginalLanguage;
        existingMovie.OriginalTitle = movie.OriginalTitle;
        existingMovie.Overview = movie.Overview;
        existingMovie.Popularity = movie.Popularity;
        existingMovie.PosterPath = movie.PosterPath;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.Title = movie.Title;
        existingMovie.Video = movie.Video;
        existingMovie.VoteAverage = movie.VoteAverage;
        existingMovie.VoteCount = movie.VoteCount;
        Update(existingMovie);
      }
    }
  }
}
