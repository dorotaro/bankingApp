using Contracts.Request;
using Contracts.Response;
using System.Threading.Tasks;

namespace Domain.Services
{
	public interface IAuthorizationService
	{
		Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);

		Task<RegisterResponseModel> RegisterAsync(RegisterRequestModel registerRequestModel);
	}
}
