using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public class RoomsDetailsServices: IRoomsDetailsServices
    {
        private readonly HotelBookingDBContext _context;

        public RoomsDetailsServices(HotelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<RoomsDetails>>> GetRoomsDetails()
        {
            if(_context.RoomsDetails == null)
            {
                throw new Exception("No Rooms are Found");
            }
            return await _context.RoomsDetails.ToListAsync();
        }
        public async Task<ActionResult<RoomsDetails>> GetRoomsDetails(int id)
        {
            var Rid = await _context.RoomsDetails.FirstOrDefaultAsync(x => x.RoomNo == id);
            if (Rid is null)
            {
                return null;
            }
            return Rid;
        }
        public async Task<ActionResult<int>> GetAvailableRoomCount(int id)
        {


            int availableRoomsCount = _context.RoomsDetails.Count(r => r.RoomAvailability == true);
            return availableRoomsCount;

        }



        public async Task<IActionResult> PutRoomsDetails(int id, RoomsDetails roomsDetails)
        {
            var Rid = await _context.RoomsDetails.FirstOrDefaultAsync(x => x.RoomNo == id);
            if (Rid is null)
            {
                return null;
            }
            Rid.Date = roomsDetails.Date;   
            Rid.Price = roomsDetails.Price;
            Rid.HotelId = roomsDetails.HotelId;
            await _context.SaveChangesAsync();
            return (IActionResult)Rid;
        }

        public async Task<ActionResult<RoomsDetails>> PostRoomsDetails(RoomsDetails roomsDetails)
        {
            await _context.RoomsDetails.AddAsync(roomsDetails);
            await _context.SaveChangesAsync();
            return roomsDetails;
        }

        public async Task<IActionResult> DeleteRoomsDetails(int id)
        {
            var Rid = await _context.RoomsDetails.FirstOrDefaultAsync(x => x.RoomNo == id);
            if (Rid is null)
            {
                return null;
            }
            _context.RoomsDetails.Remove(Rid);
            await _context.SaveChangesAsync();
            return (IActionResult)Rid;

        }


    }
}
