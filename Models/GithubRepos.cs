using System.Text.Json.Serialization;

namespace REST_API_för_CV_hantering.Models
{
    public class GithubRepos
    {
        // Get value from the name
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Get value from the language
        [JsonPropertyName("language")]
        public string Language { get; set; }

        // Get value from the description 
        [JsonPropertyName("description")]
        public string Description { get; set; }

        // Get value from the HTML URL
        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }
    }
}
