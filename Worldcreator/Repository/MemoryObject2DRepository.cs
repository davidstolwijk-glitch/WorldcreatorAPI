//using Worldcreator.Models;

//namespace Worldcreator.Repositories
//{
//    public class MemoryObject2DRepository : I2D_ObjectRepositroy
//    {
//        // Ignoring thread safety for simplicity
//        private static List<Object2D> Object2Ds = [];

//        public Task DeleteAsync(Guid id)
//        {
//            Object2Ds.Remove(Object2Ds.Single(x => x.PrefabId == id));
//            return Task.CompletedTask;
//        }

//        public Task InsertAsync(Object2D object2D)
//        {
//            Object2Ds.Add(object2D);
//            return Task.CompletedTask;
//        }

//        public Task<IEnumerable<Object2D>> SelectAsync()
//        {
//            return Task.FromResult(Object2Ds.AsEnumerable());
//        }

//        public Task<Object2D?> SelectAsync(Guid id)
//        {
//            return Task.FromResult(Object2Ds.SingleOrDefault(x => x.PrefabId == id));
//        }

//        public async Task UpdateAsync(Object2D object2D)
//        {
//            await DeleteAsync(object2D.PrefabId);
//            await InsertAsync(object2D);
//        }
//    }
//}
