using Microsoft.AspNetCore.Mvc;
using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;


namespace Hotel_Management_System.Repository.BookingDetails
{

    public interface IBookingDetailsServices
    {
        public Task<ActionResult<IEnumerable<BookingDetail>>> GetBookings();
        public Task<ActionResult<BookingDetail>> GetBookingDetails(int id);
        public Task<IActionResult> PutBookingDetails(int id, BookingDetail bookingDetails);
        public Task<ActionResult<BookingDetail>> PostBookingDetails(BookingDetail bookingDetails);
        public Task<IActionResult> DeleteBookingDetails(int id);



    }
}