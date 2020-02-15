using Grump.Abstractions;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Grump.Sql
{
    public abstract class SqlRepositoryBase
    {
        public ISecretsProvider SecretsProvider { get; set; }
        public SqlRepositoryBase(ISecretsProvider secretsProvider)
        {
            SecretsProvider = secretsProvider;
        }

        protected async Task<SqlConnection> GetOpenConnection()
        {
            var connectionString = await SecretsProvider.GetSecretAsync("sqlconnectionstring");

            var connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            return connection;
        }

        protected async Task<SqlDataReader> GetDataReader(SqlCommand command)
        {

            using (var connection = await GetOpenConnection())
            {
                using (command.Connection = connection)
                {

                    return await command.ExecuteReaderAsync();
                }
            }
        }

        protected async Task<DataSet> GetDataSet(SqlCommand command)
        {

            using (var connection = await GetOpenConnection())
            {
                command.Connection = connection;

                using (var dataAdapter = new SqlDataAdapter(command))
                {
                    var dataset = new DataSet();

                    dataAdapter.Fill(dataset);

                    return dataset;

                }

            }
        }

        protected async Task ExecuteNonQuery(SqlCommand command)
        {


            using (var connection = await GetOpenConnection())
            {
                using (command.Connection = connection)
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        protected SqlParameter CreateSqlParameter(string parameterName, SqlDbType type, object value, ParameterDirection direction, int? size = null)
        {
            SqlParameter parameter = new SqlParameter(parameterName, type)
            {
                Direction = direction,
                Value = value

            };

            if (size.HasValue)
            {
                parameter.Size = size.Value;
            }

            return parameter;

        }

        protected SqlParameter CreateSqlParameter(string parameterName, SqlDbType type, object value, int? size = null)
        {
            return CreateSqlParameter(parameterName, type, value, ParameterDirection.Input, size);

        }


        protected SqlParameter CreateSqlOutputParameter(string parameterName, SqlDbType type, int? size = null)
        {
            return CreateSqlParameter(parameterName, type, null, ParameterDirection.Output, size);

        }

    }
}