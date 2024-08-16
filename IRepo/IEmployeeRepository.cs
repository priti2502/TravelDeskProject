using TravelDesk.Models;

namespace Teavel_Desk_Project.RepoInterface
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
    }
}
