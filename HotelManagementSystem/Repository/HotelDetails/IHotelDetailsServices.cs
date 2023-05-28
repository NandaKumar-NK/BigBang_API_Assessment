using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public interface IHotelDetailsServices
    {
        public Task<ActionResult<List<HotelDetails>>> GetHotelDetails();

        public Task<List<HotelDetails>> FilterHotels(string location);
        public Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails);
        public Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails);
        public Task<IActionResult> DeleteHotelDetails(int id);

        }
}
