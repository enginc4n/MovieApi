using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace WebAPI.Service;

public class MovieUpdateService : IHostedService, IDisposable
{
  private readonly IServiceScopeFactory _scopeFactory;
  private readonly IMovieService _movieService;
  private Timer _timer;

  public MovieUpdateService(IServiceScopeFactory scopeFactory, IMovieService movieService)
  {
    _scopeFactory = scopeFactory;
    _movieService = movieService;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    _timer = new Timer(async state =>
    {
      using (IServiceScope scope = _scopeFactory.CreateScope())
      {
        MovieApiContext context = scope.ServiceProvider.GetRequiredService<MovieApiContext>();
        IDataResult<List<Movie>> dataResult = _movieService.GetList();

        context.Movies.AddRange(dataResult.Data);
        await context.SaveChangesAsync();
      }
    }, null, TimeSpan.Zero, TimeSpan.FromHours(12));

    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    _timer?.Change(Timeout.Infinite, 0);
    return Task.CompletedTask;
  }

  public void Dispose()
  {
    _timer?.Dispose();
  }
}
