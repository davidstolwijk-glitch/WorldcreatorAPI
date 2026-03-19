using Worldcreator.Models;

namespace Worldcreator.Repositories
{
    public interface IEnvironment2DRepository
    {
        Task InsertAsync(Environment2D environment);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Environment2D>> SelectAsync();
        Task<Environment2D?> SelectAsync(Guid idSelect);
        Task UpdateAsync(Environment2D environment);
    }
}