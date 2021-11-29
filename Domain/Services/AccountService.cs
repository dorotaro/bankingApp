using Contracts.Enums;
using Contracts.Request;
using Contracts.Response;
using Persistence.Models.WriteModels;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<AccountCreateResponseModel> GetUserAccount(Guid accountId)
		{
			var accounts = await _accountRepository.GetUserAccount(accountId);

			if (accounts.Count() > 0)
			{
				var account = new AccountCreateResponseModel
				{
					AccountId = accounts.FirstOrDefault().Id,
					Currency = (Currency)Enum.Parse(typeof(Currency), accounts.FirstOrDefault().Currency)
				};

				return account;
			}
			return null;
		}

		public async Task<IEnumerable<AccountCreateResponseModel>> GetUserAccounts(Guid userId)
		{
			var accounts = await _accountRepository.GetUserAccounts(userId);

			var userAccounts = new List<AccountCreateResponseModel>();

			if (accounts.Count() > 0)
			{
				foreach (var account in accounts)
				{
					var userAccount = new AccountCreateResponseModel
					{
						AccountId = account.Id,
						Currency = (Currency)Enum.Parse(typeof(Currency), account.Currency)
					};

					userAccounts.Add(userAccount);
				}
				return userAccounts;
			}
			return null;
			
		}

		public async Task<AccountCreateResponseModel> SaveAsync(AccountCreateRequestModel acountCreateRequestModel)
		{
			var accountWriteModel = new AccountWriteModel
			{
				Id = Guid.NewGuid(),
				UserId = acountCreateRequestModel.UserId,
				Currency = acountCreateRequestModel.Currency.ToString(),
				DateCreated = DateTime.UtcNow
			};

			await _accountRepository.SaveAsync(accountWriteModel);

			return new AccountCreateResponseModel
			{
				AccountId = accountWriteModel.Id,
				Currency = (Currency)Enum.Parse(typeof(Currency), acountCreateRequestModel.Currency.ToString())
			};
		}
	}
}
