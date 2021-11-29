using System;
using System.Text.Json.Serialization;

namespace Persistence.Models.ReadModels
{
    public class RegisterReadModel
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
        
        [JsonPropertyName("idToken")]
        public string IdToken { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
        
        [JsonPropertyName("expiresIn")]
        public string ExpiresIn { get; set; }
        
        [JsonPropertyName("localId")]
        public string LocalId { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("DateCreated")]
        public DateTime DateCreated { get; set; }
  }
}