
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetUserById(int id);
        public User AddUser(User user);
        public User UpdateUser(int ind, User user);
        public bool DeleteUser(int id);
        
    }
}
