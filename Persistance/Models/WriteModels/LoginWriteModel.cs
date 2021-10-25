﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Persistance.Models.WriteModels
{
	public class LoginWriteModel
	{
		[JsonPropertyName("email")]
		public string Email { get; set; }

		[JsonPropertyName("password")]
		public string Password { get; set; }

		[JsonPropertyName("returnSecureToken")]
		public bool ReturnSecureToken { get; set; } = true;
	}
}
