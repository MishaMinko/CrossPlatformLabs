using Newtonsoft.Json;

namespace Lab13.Models
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string? AccessToken { get; set; }
    }
}
