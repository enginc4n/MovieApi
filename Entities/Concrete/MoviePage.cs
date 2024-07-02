using Newtonsoft.Json;

namespace Entities.Concrete;

public class MoviePage
{
  [JsonProperty("page")]
  public int Page { get; set; }

  [JsonProperty("total_results")]
  public int TotalResults { get; set; }

  [JsonProperty("total_pages")]
  public int TotalPages { get; set; }

  [JsonProperty("results")]
  public List<Movie> Results { get; set; }
}
