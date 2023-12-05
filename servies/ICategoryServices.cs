
using Entities;

namespace servies
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllCategory();
    }
}