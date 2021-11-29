using Contracts.Request;
using Contracts.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAccountService
	{
		Task<AccountCreateResponseModel> SaveAsync(AccountCreateRequestModel AcountCreateRequestModel);

		Task<IEnumerable<AccountCreateResponseModel>> GetUserAccounts(Guid userId);

		Task<AccountCreateResponseModel> GetUserAccount(Guid accountId);
	}
}
