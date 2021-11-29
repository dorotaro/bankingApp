using System.Text.Json.Serialization;

namespace Persistence.Models.WriteModels
{
    public class RegisterWriteModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("returnSecureToken")]
        public bool ReturnSecureToken { get; set; } = true;

    }
}