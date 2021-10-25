﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Persistance.Models.ReadModels
{
	public class LoginReadModel
  {
		[JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("localId")]
    public string LocalId { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    [JsonPropertyName("idToken")]
    public string IdToken { get; set; }
    [JsonPropertyName("registered")]
    public bool Registered { get; set; }

    [JsonPropertyName("refreshToken")]
    public string RefreshToken { get; set; }
    [JsonPropertyName("expiresIn")]
    public string ExpiresIn { get; set; }
	}
}
