using BankingApp.HelperModels;
using Contracts.Enums;
using Contracts.Request;
using Contracts.Response;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly IUserService _userService;

		private readonly IAccountService _accountService;

		public AccountController(IUserService userService, IAccountService accountService)
		{
			_userService = userService;
			_accountService = accountService;
		}

		[HttpPost]
		[Route("createUserBankAccount")]
		[Authorize]
		public async Task<ActionResult<AccountCreateResponseModel>> CreateUserBankAccount(Currency currency)
		{
			var firebaseClaims = new FirebaseClaims();

			var response = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "firebase").Value;

			firebaseClaims = JsonSerializer.Deserialize<FirebaseClaims>(response);

			var user = await _userService.GetUserByEmail(firebaseClaims.FirebaseClaimResult.Email[0]);

			if (user == null) return NotFound("There is no user with this email!");

			var acountCreateRequestModel = new AccountCreateRequestModel
			{
				Currency = currency,
				UserId = user.Id
			};

			var acountCreateResponseModel = await _accountService.SaveAsync(acountCreateRequestModel);

			return Ok(acountCreateResponseModel);
		}

		[HttpGet]
		[Route("getUserAccounts")]
		[Authorize]
		public async Task<ActionResult<AccountCreateResponseModel>> GetUserBankAccounts()
		{
			var firebaseClaims = new FirebaseClaims();

			var response = HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == "firebase").Value;

			firebaseClaims = JsonSerializer.Deserialize<FirebaseClaims>(response);

			var user = await _userService.GetUserByEmail(firebaseClaims.FirebaseClaimResult.Email[0]);

			if (user == null) return NotFound("There is no user with this email!");

			var userAccounts = await _accountService.GetUserAccounts(user.Id);

			if (userAccounts != null)
			{
				return Ok(userAccounts);
			}

			return NotFound($"User have no accounts yet!");
		}
	}
}
