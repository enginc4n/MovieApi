using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : Controller
{
  private IMovieService _movieService;

  public MoviesController(IMovieService movieService)
  {
    _movieService = movieService;
  }

  [HttpGet("getlist")]
  public IActionResult GetList()
  {
    IDataResult<List<Movie>> dataResult = _movieService.GetList();
    if (dataResult.Success)
    {
      return Ok(dataResult.Data);
    }

    return BadRequest(dataResult.Message);
  }

  [HttpGet("getlistbycategory")]
  public IActionResult GetListByCategory(List<int> genreIds)
  {
    IDataResult<List<Movie>> dataResult = _movieService.GetByGenreIds(genreIds);
    if (dataResult.Success)
    {
      return Ok(dataResult.Data);
    }

    return BadRequest(dataResult.Message);
  }

  [HttpGet("get")]
  public IActionResult Get(int movieId)
  {
    IDataResult<Movie> dataResult = _movieService.GetById(movieId);
    if (dataResult.Success)
    {
      return Ok(dataResult.Data);
    }

    return BadRequest(dataResult.Message);
  }

  [HttpPost("add")]
  public IActionResult Add(Movie movie)
  {
    IResult result = _movieService.Add(movie);
    if (result.Success)
    {
      return Ok("Added");
    }

    return BadRequest(result.Message);
  }

  [HttpPost("update")]
  public IActionResult Update(Movie movie)
  {
    IResult result = _movieService.Update(movie);
    if (result.Success)
    {
      return Ok("Updated");
    }

    return BadRequest(result.Message);
  }

  [HttpPost("delete")]
  public IActionResult Delete(Movie movie)
  {
    IResult result = _movieService.Delete(movie);
    if (result.Success)
    {
      return Ok("Deleted");
    }

    return BadRequest(result.Message);
  }

  [HttpPost("ratemovie")]
  public IActionResult RateMovie(int movieId, double rating)
  {
    IResult result = _movieService.RateMovie(movieId, rating);
    if (result.Success)
    {
      return Ok("Rated");
    }

    return BadRequest(result.Message);
  }

  [HttpPost("addnotetomovie")]
  public IActionResult AddNoteToMovie(int movieId, string note)
  {
    IResult result = _movieService.AddNoteToMovie(movieId, note);
    if (result.Success)
    {
      return Ok("Noted");
    }

    return BadRequest(result.Message);
  }
}
