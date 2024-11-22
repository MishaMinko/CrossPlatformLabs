using Newtonsoft.Json;

namespace Lab5.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }
    }
}
