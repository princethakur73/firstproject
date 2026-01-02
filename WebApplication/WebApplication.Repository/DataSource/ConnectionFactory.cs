using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Threading;

namespace WebApplication.Repository.DataSource
{
	public static class ConnectionFactory
	{
		// Uses the same connection string source used elsewhere in the project.
		private static readonly string _connectionString = DatabaseConnection.ConnectionString;

		/// <summary>
		/// Creates and opens a MySqlConnection with a small retry/backoff when the server
		/// returns a max-user-connections error (or equivalent). Keep retries low to avoid
		/// compounding overload.
		/// </summary>
		/// <param name="maxRetries">Maximum attempts (default 3).</param>
		/// <param name="baseDelayMs">Base backoff delay in ms (multiplied by attempt number).</param>
		/// <returns>An opened MySqlConnection. Caller must Dispose/Close it (use using).</returns>
		public static MySqlConnection CreateOpenConnection(int maxRetries = 3, int baseDelayMs = 100)
		{
			int attempt = 0;
			while (true)
			{
				attempt++;
				try
				{
					var conn = new MySqlConnection(_connectionString);
					conn.Open();
					Trace.TraceInformation($"DB connection opened (attempt {attempt}).");
					return conn;
				}
				catch (MySqlException ex)
				{
					// MySQL error code for user connection limit is commonly 1226 (ER_USER_LIMIT_REACHED)
					// Also check message for "max_user_connections" in case different driver/culture.
					bool isUserLimit = ex.Number == 1226 || ex.Message.IndexOf("max_user_connections", StringComparison.OrdinalIgnoreCase) >= 0;

					Trace.TraceWarning($"DB connection attempt {attempt} failed: {ex.Message}");

					if (!isUserLimit || attempt >= maxRetries)
					{
						// Give up and rethrow the original exception
						Trace.TraceError($"DB connection failed permanently after {attempt} attempts.");
						throw;
					}

					// Backoff and retry (short, incremental)
					int delay = baseDelayMs * attempt;
					Trace.TraceInformation($"Retrying DB connection after {delay}ms backoff (attempt {attempt + 1}).");
					Thread.Sleep(delay);
				}
			}
		}
	}
}