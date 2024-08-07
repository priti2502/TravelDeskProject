using System.Collections.Generic;
using System.Threading.Tasks;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public interface ITravelRequestRepository
    {
        List<TravelRequest> GetAll();
        TravelRequest GetTravelRequestById(int id);
        TravelRequest AddTravelRequest(TravelRequest travelRequest);
        TravelRequest UpdateTravelRequest(int id, TravelRequest travelRequest);
        bool DeleteTravelRequest(int id);
    }
}
