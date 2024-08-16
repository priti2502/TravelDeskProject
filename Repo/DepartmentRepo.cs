using TravelDesk.Context;
using TravelDesk.Models;

using TravelDeskWebApi.IRepo;


namespace TravelDeskWebApi.Repo
{

    public class DepartmentRepo :IDepartmentRepo
    {
        TravelDeskContext _context;
        public DepartmentRepo(TravelDeskContext context)
        {
            _context = context;

        }
        public List<Department> GetAllDepts()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
        }
    }
}
