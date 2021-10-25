using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Persistance.Clients;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration
{
	public static class ServiceExtensions
	{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
      return services
          .AddSqlClients(configuration)
          .AddHttpClients(configuration)
          .AddRepositories();
    }

    private static IServiceCollection AddSqlClients(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionStringBuilder = new MySqlConnectionStringBuilder()
      {
        Server = "Localhost",
        Port = 3306,
        UserID = "dorota",
        Password = "twvYGKJ4h+8n57%m",
        Database = "test"
      };

      var connectionString1 = connectionStringBuilder.ConnectionString;

      var connectionString = configuration.GetSection("ConnectionStrings")["SqlConnectionString"];

      return services
          .AddTransient<ISqlClient>(_ => new SqlClient(connectionString));
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			return services
					.AddSingleton<IUserRepository, UserRepository>()
					.AddSingleton<IAccountRepository, AccountRepository>()
          .AddSingleton<ITransactionRepository, TransactionRepository>();

    }

		private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {

      var apiKey = configuration.GetSection("FireBaseConnectionStrings")["ApiKey"];

      services.AddTransient<HttpClient>();

      services.AddHttpClient<IFirebaseClient, FirebaseClient>(c =>
          c.BaseAddress = new Uri("https://identitytoolkit.googleapis.com/v1"));

      services.AddHttpClient<IFirebaseClient, FirebaseClient>(c =>
          c.DefaultRequestHeaders.Add("key", apiKey));

      return services;

    }
  }
}
