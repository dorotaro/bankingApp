using Contracts.Request;
using Contracts.Response;
using Persistance.Clients;
using Persistance.Models.ReadModels;
using Persistance.Models.WriteModels;
using Persistance.Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
	public class AuthorizationService : IAuthorizationService
	{
		private readonly IFirebaseClient _firebaseClient;
		private readonly IUserRepository _usersRepository;

		public AuthorizationService(IFirebaseClient firebaseClient, IUserRepository usersRepository)
		{
			_firebaseClient = firebaseClient;
			_usersRepository = usersRepository;
		}
		public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
		{

			var loginWriteModel = new LoginWriteModel
			{
				Email = loginRequestModel.Email,
				Password = loginRequestModel.Password
			};

			var firebaseLoginResponse = await _firebaseClient.LoginAsync<LoginWriteModel, LoginReadModel>(loginWriteModel);

			return new LoginResponseModel
      {
				Email = firebaseLoginResponse.Email,
				IdToken = firebaseLoginResponse.IdToken
			};
    }

		public async Task<RegisterResponseModel> RegisterAsync(RegisterRequestModel registerRequestModel)
		{
			var registerWriteModel = new RegisterWriteModel
			{
				Email = registerRequestModel.Email,
				Password = registerRequestModel.Password
			};


			var firebaseRegisterResponse = await _firebaseClient.RegisterAsync<RegisterWriteModel, RegisterReadModel>(registerWriteModel);
			var userWriteModel = new UserWriteModel
			{
				Id = Guid.NewGuid(),
				Email = firebaseRegisterResponse.Email,
				DateCreated = DateTime.Now
			};

			await _usersRepository.SaveAsync(userWriteModel);

			return new RegisterResponseModel
			{
				Email = firebaseRegisterResponse.Email,
				IdToken = firebaseRegisterResponse.IdToken
			};
		}
	}
}
