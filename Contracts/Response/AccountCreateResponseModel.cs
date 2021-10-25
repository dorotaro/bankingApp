using Contracts.Enums;
using System;

namespace Contracts.Response
{
	public class AccountCreateResponseModel
	{
		public Guid AccountId { get; set; }

		public Currency Currency { get; set; }
	}
}
