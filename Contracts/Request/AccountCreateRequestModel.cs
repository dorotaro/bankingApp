using Contracts.Enums;
using System;

namespace Contracts.Request
{
	public class AccountCreateRequestModel
	{
		public Currency Currency { get; set; }

		public Guid UserId { get; set; }
	}
}
