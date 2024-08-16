using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TravelDeskContext _context;

        public AdminRepository(TravelDeskContext context)
        {
            _context = context;
        }

        // Adds a new user to the database
        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        // Deletes a user from the database by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users
                .Include(u => u.Role) // Include Role
                .Include(u => u.Department) // Include Department
                .Include(u => u.Manager) // Include Manager (self-join)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Retrieves all users from the database
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Role) // Include Role
                .Include(u => u.Department) // Include Department
                .Include(u => u.Manager) // Include Manager (self-join)
                .ToListAsync();
        }

        // Retrieves a user by ID
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Updates an existing user by ID
        public async Task<User?> UpdateAsync(int id, User user)
        {
            var existingUser = await _context.Users
                .Include(u => u.Role)
                .Include(u => u.Department)
                .Include(u => u.Manager)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Password = user.Password;
                existingUser.MobileNum = user.MobileNum;
                await _context.SaveChangesAsync();
            }
            return existingUser;
        }

        // Retrieves all users with the role "Manager"
        public async Task<IEnumerable<User>> GetManagersAsync()
        {
            return await _context.Users
                .Include(u => u.Role) // Include Role
                .Where(u => u.Role.RoleName == "Manager" && u.IsActive)
                .ToListAsync();
        }
    }
}
