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
  public IActionResult GetList(int pageSize, int pageNumber)
  {
    IDataResult<List<Movie>> dataResult = _movieService.GetList(pageSize, pageNumber);
    if (dataResult.Success)
    {
      return Ok(dataResult.Data);
    }

    return BadRequest(dataResult.Message);
  }

  [HttpGet("getbyid")]
  public IActionResult Get(int movieId)
  {
    IDataResult<Movie?> dataResult = _movieService.GetById(movieId);
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
}
