using Contracts.Request;
using Contracts.Response;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankingApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthorizationService _authService;

		private readonly IUserService _userService;

		public AuthenticationController(IAuthorizationService authService, IUserService userService)
		{
			_authService = authService;
			_userService = userService;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<ActionResult<RegisterResponseModel>> Register(RegisterRequestModel registerRequestModel)
		{

			var user = await _userService.GetUserByEmail(registerRequestModel.Email);

			if (user != null) return BadRequest("User with this email already exists!");

			var model = await _authService.RegisterAsync(registerRequestModel);

			if (model.Email == registerRequestModel.Email)
			{
				return Ok($"User with email {registerRequestModel.Email} created");
			}

			return BadRequest("Something went wrong");


		}

		[HttpPost]
		[Route("Login")]
		public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginRequestModel)
		{

			var user = await _userService.GetUserByEmail(loginRequestModel.Email);

			if (user == null) return NotFound("There is no such user with these credentials!");

			var model = await _authService.LoginAsync(loginRequestModel);

			if (model.Email == loginRequestModel.Email)
			{
				return (model);
			}

			return BadRequest("Something went wrong");
		}
	}
}
