//using Worldcreator.Models;

//namespace Worldcreator.Repositories
//{
//    public class MemoryEnvironment2DRepository : IEnvironment2DRepository
//    {
//        private static List<Environment2D> environments2D = [];

//        public Task DeleteAsync(Guid id)
//        {
//            environments2D.Remove(environments2D.Single(x => x.Id == id));
            
//            return Task.CompletedTask;
//        }

//        public Task InsertAsync(Environment2D environment)
//        {
//            environments2D.Add(environment);
//            return Task.CompletedTask;
//        }


//        public Task<IEnumerable<Environment2D>> SelectAsync()
//        {
//            return Task.FromResult(environments2D.AsEnumerable());
//        }

//        // overload word hier gebruikt
//        public Task<Environment2D?> SelectAsync(Guid id)
//        {
//            return Task.FromResult(environments2D.SingleOrDefault(x => x.Id == id));
//        }

//        public async Task UpdateAsync(Environment2D environment) 
//        {
//            await DeleteAsync(environment.Id);
//            await InsertAsync(environment);
//        }

//    }
//}
