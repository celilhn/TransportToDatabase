using System.Text.Json.Serialization;

namespace Application.Models
{
    public class PeopleExternalIDModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("freebase_mid")]
        public object FreebaseMid { get; set; }

        [JsonPropertyName("freebase_id")]
        public object FreebaseId { get; set; }

        [JsonPropertyName("imdb_id")]
        public string ImdbId { get; set; }

        [JsonPropertyName("tvrage_id")]
        public int TvrageId { get; set; }

        [JsonPropertyName("facebook_id")]
        public object FacebookId { get; set; }

        [JsonPropertyName("instagram_id")]
        public object InstagramId { get; set; }

        [JsonPropertyName("twitter_id")]
        public object TwitterId { get; set; }
    }
}
