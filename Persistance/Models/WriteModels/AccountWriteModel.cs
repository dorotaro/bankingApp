using System;

namespace Persistence.Models.WriteModels
{
	public class AccountWriteModel
	{
		public Guid Id { get; set; }

		public Guid UserId { get; set; }

		public string Currency { get; set; }

		public DateTime DateCreated { get; set; }
	}
}
