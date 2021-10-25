using Contracts.Request;
using Contracts.Response;
using Persistance.Models.WriteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
	public interface IAuthorizationService
	{
		Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);

		Task<RegisterResponseModel> RegisterAsync(RegisterRequestModel registerRequestModel);
	}
}
