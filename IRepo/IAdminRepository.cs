using System.Collections.Generic;
using System.Threading.Tasks;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<User>> GetManagersAsync(); 
    }
}
