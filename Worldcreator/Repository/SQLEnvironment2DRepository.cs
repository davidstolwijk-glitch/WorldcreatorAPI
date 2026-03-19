using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi;
using Worldcreator.Models;
using Worldcreator.Repositories;

namespace Worldcreator.Repository
{
    public class SQLEnvironment2DRepository : IEnvironment2DRepository
    {

        private readonly string sqlConnectionString;

        public SQLEnvironment2DRepository(string sqlConnectionString)
        { 
            this.sqlConnectionString = sqlConnectionString;
        }


        public async Task InsertAsync(Environment2D environment)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync(
                    "INSERT INTO [Environment2D] (Id, Name, MaxHeight, MaxLength, UserID)" +
                    " VALUES (@Id, @Name, @MaxHeight, @MaxLength ,@UserID)",
                    environment
                );
            }
        }





        public async Task<Environment2D?> SelectAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QuerySingleOrDefaultAsync<Environment2D>("SELECT * FROM [Environment2D] WHERE Id = @Id", new { id });
            }
        }

        public async Task<IEnumerable<Environment2D>> SelectAsync()
        {

            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QueryAsync<Environment2D>("SELECT * FROM [Environment2D]");
            }
        }


        public async Task UpdateAsync(Environment2D environment)
        {

            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("UPDATE [Environment2D] Set" + 
                                                 "Name = @Name, " +
                                                 "Number = @Number " +
                                                 "WHERE Id = @Id", environment);
            }
        }

        public async Task DeleteAsync(Guid id) 
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("DELETE FROM [Environment2D] WHERE Id = @Id", new {id});
            }

        }

    }
}
