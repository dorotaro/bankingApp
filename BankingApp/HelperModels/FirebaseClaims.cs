using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankingApp.HelperModels
{
	public class FirebaseClaims
	{
		[JsonPropertyName("identities")]
		public FirebaseClaimResult FirebaseClaimResult { get; set; }
	}

	public class FirebaseClaimResult
	{
		[JsonPropertyName("email")]
		public string[] Email { get; set; }
	}
}
