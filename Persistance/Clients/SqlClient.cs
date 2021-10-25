using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Clients
{
	public class SqlClient : ISqlClient
	{
		private readonly string _connectionString;
		public SqlClient(string connectionString)
		{
			_connectionString = connectionString;
		}
		public async Task Execute<T>(string query, object param)
		{
			using var connection = new MySqlConnection(_connectionString);

			connection.Open();

			await connection.ExecuteAsync(query, param);
			
		}

		public async Task<IEnumerable<T>> Query<T>(string query, object param)
		{
			using var connection = new MySqlConnection(_connectionString);

			connection.Open();

			return await connection.QueryAsync<T>(query, param);
		}
	}
}
