using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Configuration;

namespace Domain
{
	public static class ServiceExtension
	{
		public static IServiceCollection AddDomain(this IServiceCollection service, IConfiguration configuration)
		{
			return service
				.AddServices()
				.AddPersistanceServices(configuration);
		}

		private static IServiceCollection AddServices(this IServiceCollection service)
		{
			return service
				.AddSingleton<IUserService, UserService>()
				.AddSingleton<IAuthorizationService, AuthorizationService>()
				.AddSingleton<IAccountService, AccountService>()
				.AddSingleton<ITransactionService, TransactionService>();
		}

		private static IServiceCollection AddPersistanceServices(this IServiceCollection service, IConfiguration configuration)
		{
			return service.AddPersistance(configuration);
		}
	}
}
