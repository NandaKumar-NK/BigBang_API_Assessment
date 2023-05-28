using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public interface IRoomsDetailsServices
    {
        public Task<ActionResult<IEnumerable<RoomsDetails>>> GetRoomsDetails();
        public  Task<ActionResult<RoomsDetails>> GetRoomsDetails(int id);

        public Task<ActionResult<int>> GetAvailableRoomCount(int id);

        public Task<IActionResult> PutRoomsDetails(int id, RoomsDetails roomsDetails);

        public   Task<ActionResult<RoomsDetails>> PostRoomsDetails(RoomsDetails roomsDetails);
        public  Task<IActionResult> DeleteRoomsDetails(int id);




    }
}
