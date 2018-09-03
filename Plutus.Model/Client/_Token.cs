using Newtonsoft.Json;

namespace Plutus.Model.Client
{
    public class _Token
    {
        [JsonProperty(PropertyName = "id_token")]
        public string TokenId { get; set; }
        [JsonProperty(PropertyName = "access_token")]
        public string Acccess { get; set; }
        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string Type { get; set; }
    }
}
