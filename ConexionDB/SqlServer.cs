using System.Data;
using AccessUtilities;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
namespace ConexionDB
{
    public class SqlServer
    {
        protected readonly string cn;

        public SqlServer(string cn) => this.cn = cn;

        public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, Parameter parameter, int timeout = 0) where T : class
        {
            return await TransaccionAsync<T>(procedure, new List<Parameter> { parameter }, timeout);
        }

        public async Task<ICollection<T>> TransaccionAsync<T>(string procedure, ICollection<Parameter> parameters, int timeout = 0) where T : class
        {
            IEnumerable<T> list = new List<T>();

            using (SqlConnection connection = new SqlConnection(cn))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = procedure;

                    if (timeout > 0) { command.CommandTimeout = timeout; }

                    if (parameters.Any())
                    {
                        foreach (Parameter parameter in parameters) { command.Parameters.AddWithValue(parameter.key, parameter.value.IsNull()); }
                    }

                    await connection.OpenAsync();

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows) list = Mapper.Map<IDataReader, IEnumerable<T>>(reader);
                    }
                }
            }

            return list.ToList();
        }
        public class SqlBulkCopyRespose
        {
            public bool IsValid { get; set; }
            public string Message { get; set; }
        }
        public async Task<SqlBulkCopyRespose> SqlBulkCopy<T>(List<T> items, string TableName)
        {
            string json = JsonConvert.SerializeObject(items);
            DataTable table = JsonConvert.DeserializeObject<DataTable>(json);
            try
            {
                using (var sqlCopy = new SqlBulkCopy(cn))
                {
                    sqlCopy.DestinationTableName = TableName;
                    sqlCopy.BatchSize = table.Rows.Count;
                    foreach (DataColumn column in table.Columns)
                    {
                        sqlCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(column.ColumnName, column.ColumnName));
                    }
                    await sqlCopy.WriteToServerAsync(table);
                    return await Task.Run(() => new SqlBulkCopyRespose { IsValid = true, Message = "" });
                }
            }
            catch (Exception ex)
            {
                return await Task.Run(() => new SqlBulkCopyRespose { IsValid = false, Message = ex.Message });
            }

        }

        public async Task ExecuteStringSql(string sql)
        {
            using (SqlConnection connection = new SqlConnection(cn))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    connection.Close();
                }
            }

        }
    }
}
