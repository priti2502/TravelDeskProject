using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelDesk.Context;
using TravelDesk.Models;

namespace TravelDesk.Repositories
{
    public class TravelRequestRepository : ITravelRequestRepository
    {
        private readonly UserDBContext _context;

        public TravelRequestRepository(UserDBContext context)
        {
            _context = context;
        }

        public List<TravelRequest> GetAll()
        {
            return _context.TravelRequests.ToList();
        }

        public TravelRequest GetTravelRequestById(int id)
        {
            return _context.TravelRequests.Find(id);
        }

        public TravelRequest AddTravelRequest(TravelRequest travelRequest)
        {
            _context.TravelRequests.Add(travelRequest);
            _context.SaveChanges();
            return travelRequest;
        }

        public TravelRequest UpdateTravelRequest(int id, TravelRequest travelRequest)
        {
            var existingRequest = _context.TravelRequests.Find(id);
            if (existingRequest == null)
            {
                return null;
            }

            existingRequest.EmployeeId = travelRequest.EmployeeId;
            existingRequest.EmployeeName = travelRequest.EmployeeName;
            existingRequest.ProjectName = travelRequest.ProjectName;
            existingRequest.DepartmentName = travelRequest.DepartmentName;
            existingRequest.TravelReason = travelRequest.TravelReason;
            existingRequest.BookingType = travelRequest.BookingType;
            existingRequest.TravelDate = travelRequest.TravelDate;
            existingRequest.AadharCard = travelRequest.AadharCard;
            existingRequest.PassportNumber = travelRequest.PassportNumber;
            existingRequest.VisaFile = travelRequest.VisaFile;
            existingRequest.DaysOfStay = travelRequest.DaysOfStay;
            existingRequest.MealPreference = travelRequest.MealPreference;

            _context.TravelRequests.Update(existingRequest);
            _context.SaveChanges();
            return existingRequest;
        }

        public bool DeleteTravelRequest(int id)
        {
            var travelRequest = _context.TravelRequests.Find(id);
            if (travelRequest == null)
            {
                return false;
            }

            _context.TravelRequests.Remove(travelRequest);
            _context.SaveChanges();
            return true;
        }
    }
}

