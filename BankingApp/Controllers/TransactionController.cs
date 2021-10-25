using BankingApp.HelperModels;
using Contracts.Request;
using Contracts.Response;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TransactionController : ControllerBase
	{
		private readonly IUserService _userService;

		private readonly IAccountService _accountService;

		private readonly ITransactionService _transactionService;

		public TransactionController(IUserService userService, IAccountService accountService, ITransactionService transactionService)
		{
			_userService = userService;
			_accountService = accountService;
			_transactionService = transactionService;
		}

		[HttpPost]
		[Route("TopUpUserAccount")]
		[Authorize]
		public async Task<ActionResult> TopUpUserAccount(decimal amount, Guid accountId)
		{
			var firebaseClaims = new FirebaseClaims();

			var response = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "firebase").Value;

			firebaseClaims = JsonSerializer.Deserialize<FirebaseClaims>(response);

			var user = await _userService.GetUserByEmail(firebaseClaims.FirebaseClaimResult.Email[0]);

			if (user == null) return NotFound("There is no user with connected credentials!");

			var account = await _accountService.GetUserAccount(accountId);

			if (account == null) return NotFound("There is no account with id!");

			var transactionRequestModel = new TransactionRequestModel
			{
				SenderAccountNumberId = accountId,
				ReceiverAccountNumberId = accountId,
				Amount = amount,
				Currency = account.Currency
			};

			await _transactionService.TopUpAccount(transactionRequestModel);

			return Ok($"Added {amount} {account.Currency} to account");
		}

		[HttpGet]
		[Route("GetAccountBalance")]
		[Authorize]
		public async Task<ActionResult<AccountCreateResponseModel>> GetAccountBalance(Guid accountId)
		{
			var firebaseClaims = new FirebaseClaims();

			var response = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "firebase").Value;

			firebaseClaims = JsonSerializer.Deserialize<FirebaseClaims>(response);

			var user = await _userService.GetUserByEmail(firebaseClaims.FirebaseClaimResult.Email[0]);

			if (user == null) return NotFound("There is no user with connected credentials!");

			var account = await _accountService.GetUserAccount(accountId);

			if (account == null) return NotFound("There is no account with id!");

			var accountBalance = await _transactionService.GetAccountBalance(account.AccountId);

			return Ok($"Balance is {accountBalance} {account.Currency}");

		}

		[HttpPost]
		[Route("CreateOutgoingTransaction")]
		[Authorize]
		public async Task<IActionResult> CreateOutgoingTransaction(decimal amount, Guid accountId, Guid receiverAccountId)
		{
			var firebaseClaims = new FirebaseClaims();

			var response = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "firebase").Value;

			firebaseClaims = JsonSerializer.Deserialize<FirebaseClaims>(response);

			var user = await _userService.GetUserByEmail(firebaseClaims.FirebaseClaimResult.Email[0]);

				if (user == null) return NotFound("There is no user with connected credentials!");

			var account = await _accountService.GetUserAccount(accountId);

				if (account == null) return NotFound("There is no account with id!");

			var accountBalance = await _transactionService.GetAccountBalance(account.AccountId);

				if(accountBalance < amount) return BadRequest("Not enough funds on your account!");

			var otherAccount = await _accountService.GetUserAccount(receiverAccountId);

				if (otherAccount == null) return NotFound("There is no receiver account with id!");
				if (otherAccount.AccountId == account.AccountId) return NotFound("You cannot send money to yourself!");
				if (account.Currency != otherAccount.Currency) return BadRequest("Your account has different currency than receiver!");

			var transactionRequestModel = new TransactionRequestModel
			{
				SenderAccountNumberId = accountId,
				ReceiverAccountNumberId = receiverAccountId,
				Amount = amount,
				Currency = otherAccount.Currency
			};

			await _transactionService.CreatePayment(transactionRequestModel);

			return Ok($"Payment send with amount of {amount} {otherAccount.Currency} to receipient wiht Id {otherAccount.AccountId}");
		}
	}
}
