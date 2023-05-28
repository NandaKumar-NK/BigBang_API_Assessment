using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public class HotelDetailsServices: IHotelDetailsServices
    {

        private readonly HotelBookingDBContext _context;

        public HotelDetailsServices(HotelBookingDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<List<HotelDetails>>> GetHotelDetails()
        {

            return await _context.HotelDetails.ToListAsync();
        }

      


        public async Task<List<HotelDetails>> FilterHotels(string location)
        {
            var query = _context.HotelDetails.AsQueryable();

            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(h => h.Location.Contains(location));
            }
          

            return await query.ToListAsync();

        }
        public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            var td = await _context.HotelDetails.FirstOrDefaultAsync(x => x.HotelId == id);
            if (td is null)
            {
                return null;
            }
            td.Location= hotelDetails.Location;
            td.HotelName= hotelDetails.HotelName;
            td.TotalRooms= hotelDetails.TotalRooms;
            td.Rooms= hotelDetails.Rooms;
            await _context.SaveChangesAsync();

            return (IActionResult)td;
        }

        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
            await _context.HotelDetails.AddAsync(hotelDetails);
           await _context.SaveChangesAsync();
            return hotelDetails;

        }
        public async Task<IActionResult> DeleteHotelDetails(int id)
        {
            var Hid = await _context.HotelDetails.FirstOrDefaultAsync(x => x.HotelId == id);
            if (Hid is null)
            {
                return null;
            }
            _context.Remove(Hid);
            await _context.SaveChangesAsync();
            return (IActionResult)Hid;

        }
    }
}
