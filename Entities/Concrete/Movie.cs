using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entities.Concrete;

public class Movie
{
  [JsonProperty("id")]
  public int Id { get; set; }

  [JsonProperty("title")]
  public string Title { get; set; }

  [JsonProperty("release_date")]
  public DateTime? ReleaseDate { get; set; }

  [JsonProperty("overview")]
  public string? Overview { get; set; }

  [JsonProperty("poster_path")]
  public string? PosterPath { get; set; }

  [JsonProperty("popularity")]
  public decimal? Popularity { get; set; }

  [JsonProperty("vote_average")]
  public decimal? VoteAverage { get; set; }

  [JsonProperty("vote_count")]
  public int? VoteCount { get; set; }

  [JsonProperty("adult")]
  public bool? Adult { get; set; }

  [JsonProperty("original_language")]
  public string? OriginalLanguage { get; set; }

  [JsonProperty("original_title")]
  public string? OriginalTitle { get; set; }

  [JsonProperty("backdrop_path")]
  public string? BackdropPath { get; set; }

  [JsonProperty("video")]
  public bool? Video { get; set; }

  [NotMapped]
  [JsonProperty("genre_ids")]
  public List<int>? GenreIdsList { get; set; }

  public string GenreIds
  {
    get => string.Join(",", GenreIdsList);
    set => GenreIdsList = string.IsNullOrEmpty(value)
      ? new List<int>()
      : new List<int>(Array.ConvertAll(value.Split(','), int.Parse));
  }
}
