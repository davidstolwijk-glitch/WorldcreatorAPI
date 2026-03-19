using Worldcreator.Models;

namespace Worldcreator.Repositories
{
    public interface I2D_ObjectRepositroy
    {
        Task InsertAsync(Object2D object2D);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Object2D>> SelectAsync();
        Task<Object2D?> SelectAsync(Guid id);
        Task UpdateAsync(Object2D object2D);
    }
}