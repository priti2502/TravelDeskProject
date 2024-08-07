using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public class UserRepository : IUserRepository
    {
        UserDBContext  _context;
        public UserRepository(UserDBContext context)
        {
            _context = context; 
        }

        public User AddUser(User user)
        {
           _context.Users.Add(user); 
            _context .SaveChanges(); 
            return user; 

        }


        public bool DeleteUser(int id)
        {
            var obj = _context.Users.FirstOrDefault(x => x.Id == id);
            if(obj!=null)
            {
                _context.Users.Remove(obj);
               _context .SaveChanges(); 

            }
            return true;

        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();

        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User UpdateUser(int id, User user)
        {
            var obj = _context.Users.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                obj.FirstName = user.FirstName; 
                obj.LastName = user.LastName;   
               
               
                obj.Password=user.Password; 
                obj.MobileNum = user.MobileNum; 
                _context.SaveChanges();


            }
            return obj;

        }

      
    }
}
