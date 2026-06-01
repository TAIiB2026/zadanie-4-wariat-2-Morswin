using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface GetDataInterface
    {
        Task<IEnumerable<KsiazkaDTO>> GetAsync();
        Task<KsiazkaDTO?> GetAsyncByID(int id);
    }
}
