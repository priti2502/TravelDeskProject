using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;
using TravelDeskWebApi.IRepo;


namespace TravelDeskWebApi.Repo
{
    public class RoleRepo : IRoleRepo
    {
       TravelDeskContext _context;
        public RoleRepo(TravelDeskContext context)
        {
            _context = context;
        }
        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(x => x.RoleId == id);
        }
    }
}
