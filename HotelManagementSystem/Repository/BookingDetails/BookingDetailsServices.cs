using Microsoft.AspNetCore.Mvc;
using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;



namespace Hotel_Management_System.Repository.BookingDetails
{
    public class BookingDetailsServices: IBookingDetailsServices
    {

        private readonly HotelBookingDBContext _context;

        public BookingDetailsServices(HotelBookingDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookings() 
        {
            if (_context.Bookings == null)
            {
                throw new Exception("No Rooms are Found");
            }
            return await _context.Bookings.ToListAsync();
        }

        public async Task<ActionResult<BookingDetail>> GetBookingDetails(int id)
        {
            var Bid = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == id);
            if (Bid is null)
            {
                return null;
            }
            return Bid;
        }

        public async Task<IActionResult> PutBookingDetails(int id, BookingDetail bookingDetails)
        {
            var bid = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId == id);
            if (bid is null)
            {
                return null;
            }
           
            bid.CheckInDate = bookingDetails.CheckInDate;
            bid.CheckOutDate = bookingDetails.CheckOutDate;
            bid.Price= bookingDetails.Price;
            bid.Customer= bookingDetails.Customer;
            bid.Rooms= bookingDetails.Rooms;
            bid.Hotel= bookingDetails.Hotel;
            await _context.SaveChangesAsync();

            return (IActionResult)bid;


        }
        public async Task<ActionResult<BookingDetail>> PostBookingDetails(BookingDetail bookingDetails)
        {
            
            await _context.Bookings.AddAsync(bookingDetails);
           await  _context.SaveChangesAsync();
            return bookingDetails;
        }

        public async Task<IActionResult> DeleteBookingDetails(int id)
        {
            var bid = await _context.Bookings.FirstOrDefaultAsync(x => x.BookingId== id);
            if (bid is null)
            {
                return null;
            }
            _context.Remove(bid);
            await _context.SaveChangesAsync();
            return (IActionResult)bid;
        }




    }
}
