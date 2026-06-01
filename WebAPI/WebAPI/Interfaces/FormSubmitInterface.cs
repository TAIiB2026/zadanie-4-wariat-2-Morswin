using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface FormSubmitInterface
    {
        Task<bool> AddAsync(KsiazkaDTO ksiazkaDto);
        Task<bool> UpdateAsync(int id, KsiazkaDTO ksiazkaDto);
    }
}
