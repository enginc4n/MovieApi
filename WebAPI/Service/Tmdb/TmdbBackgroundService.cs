using Business.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace WebAPI.Service.Tmdb;

public class TmdbBackgroundService : BackgroundService
{
  private readonly ITmdbService _tmdbService;
  private readonly IMovieRepository _movieRepository;

  public TmdbBackgroundService(ITmdbService tmdbService, IMovieRepository movieRepository)
  {
    _tmdbService = tmdbService;
    _movieRepository = movieRepository;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    int currentPage = 1;
    int totalPages = 1;

    while (!stoppingToken.IsCancellationRequested)
    {
      try
      {
        MoviePage moviesData = await _tmdbService.GetMoviesByPageAsync(currentPage);

        totalPages = moviesData.TotalPages;

        foreach (Movie movie in moviesData.Results)
        {
          await _movieRepository.AddOrUpdateMovieAsync(movie);
        }

        currentPage++;

        if (currentPage > totalPages)
        {
          currentPage = 1;
        }

        await Task.Delay(TimeSpan.FromHours(6), stoppingToken);
      }
      catch (Exception ex)
      {
        await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
      }
    }
  }
}
