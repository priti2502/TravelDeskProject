using System.ComponentModel.DataAnnotations;
using TravelDesk.Enum;
using TravelDesk.Models;

namespace TravelDesk.DTO
{
    public class HotelBookingUploadDto
    {
        [Required(ErrorMessage = "Booking Date is required.")]
        public DateTime BookingDate { get; set; }

        [Required(ErrorMessage = "Days of Stay is required.")]
        public int DaysOfStay { get; set; }

        [Required(ErrorMessage = "Meal Required is required.")]
        public MealRequired MealRequired { get; set; }

        [Required(ErrorMessage = "Meal Preference is required.")]
        public MealPreference MealPreference { get; set; }

        
    }
}