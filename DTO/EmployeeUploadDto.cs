using System.ComponentModel.DataAnnotations;
using TravelDesk.DTO;
using TeavelDesk.DTO;
using TravelDesk.Enum;
using TravelDesk.Models;

namespace TravelDesk.DTO
{
    public class EmployeeUploadDto
    {
        [Required(ErrorMessage = "Employee Name is required.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Project Name is required.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Reason for Traveling is required.")]
        public string ReasonForTraveling { get; set; }


        public Status Status { get; set; }


        // Collections for Air and Hotel Bookings
        //public AirBookingUploadDto? airBookingUploadDto { get; set; }
        //public HotelBookingUploadDto? hotelBookingUploadDto { get; set; }
        // Single Air and Hotel Booking
        public AirBookingUploadDto? AirBooking { get; set; }
        public HotelBookingUploadDto? HotelBooking { get; set; }






        //public List<AirBookingUploadDto>? AirBookings { get; set; }
        //public List<HotelBookingUploadDto>? HotelBookings { get; set; }
    }
}
