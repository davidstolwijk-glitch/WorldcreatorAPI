using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi;
using Worldcreator.Models;
using Worldcreator.Repositories;

namespace Worldcreator.Repository
{
    public class SQLObject2dRepository : I2D_ObjectRepositroy
    {
        private readonly string sqlConnectionString;

        public SQLObject2dRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public async Task InsertAsync(Object2D object2d)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
               await sqlConnection.ExecuteAsync("INSERT INTO [Object2D] (EnvironmentId, Id ,PrefabId, PositionX, PositionY, ScaleX, ScaleY, RotationZ, SortingLayer)" +
                   " VALUES ( @EnvironmentId, @Id, @PrefabId,  @PositionX, @PositionY, @ScaleX, @ScaleY, @RotationZ, @SortingLayer)", object2d);
            }
        }

        public async Task<Object2D?> SelectAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QuerySingleOrDefaultAsync<Object2D>("SELECT * FROM [Object2D] WHERE Id = @Id", new { id });   
            }
        }

        public async Task<IEnumerable<Object2D>> SelectAsync()
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QueryAsync<Object2D>("SELECT * FROM [Object2D]");
            }
        }

        public async Task UpdateAsync(Object2D object2d)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("UPDATE [Object2D] SET " +
                                                 "PositionX = @PositionX, " +
                                                 "PositionY = @PositionY " +
                                                 "ScaleX = @ScaleX, " +
                                                 "ScaleY = @ScaleY " +
                                                 "RotationZ = @RotationZ " +
                                                 "SortingLayer = @SortingLayer " +
                                                 "WHERE Id = @Id", object2d);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("DELETE FROM [ExampleObject] WHERE Id = @Id", new { id });
            }
        }
    }
}
