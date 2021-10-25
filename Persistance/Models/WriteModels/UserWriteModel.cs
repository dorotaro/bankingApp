using System;
using System.Text.Json.Serialization;

namespace Persistance.Models.WriteModels
{
	public class UserWriteModel
	{
		[JsonPropertyName("id")]
		public Guid Id { get; set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }

		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("dateCreated")]
		public DateTime DateCreated { get; set; }
	}
}
