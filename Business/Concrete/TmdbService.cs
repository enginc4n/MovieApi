using Business.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using RestSharp;

namespace Business.Concrete;

public class TmdbService : ITmdbService
{
  private readonly string _apiKey;
  private readonly string _baseUrl = "https://api.themoviedb.org/3/";

  public TmdbService()
  {
    _apiKey = "12e409b5a2567665aa630163735e7915";
  }

  public async Task<MoviePage> GetMoviesByPageAsync(int page)
  {
    RestClient client = new(_baseUrl);
    RestRequest request = new("movie/popular", Method.Get);
    request.AddParameter("api_key", _apiKey);
    request.AddParameter("page", page);

    RestResponse response = await client.ExecuteAsync(request);
    MoviePage moviePage = JsonConvert.DeserializeObject<MoviePage>(response.Content);
    return moviePage;
  }
}
