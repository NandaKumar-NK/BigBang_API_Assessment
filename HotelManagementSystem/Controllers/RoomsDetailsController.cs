using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Models;
using Hotel_Management_System.Repository.BookingDetails;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsDetailsController : ControllerBase
    {
        private readonly IRoomsDetailsServices _context;

        public RoomsDetailsController(IRoomsDetailsServices context)
        {
            _context = context;
        }

        // GET: api/RoomsDetails
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<RoomsDetails>>> GetRoomsDetails()
        {
            try
            {
                return await _context.GetRoomsDetails();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/RoomsDetails/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<RoomsDetails>> GetRoomsDetails(int id)
        {
            try
            {
                return await _context.GetRoomsDetails(id);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{hotelId}/rooms/count")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<int>> GetAvailableRoomCount(int id)
        {
            var availableRoomCount = await _context.GetAvailableRoomCount(id);
            return Ok(availableRoomCount);
        }

        // PUT: api/RoomsDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRoomsDetails(int id, RoomsDetails roomsDetails)
        {
            try
            {
                return await _context.PutRoomsDetails(id, roomsDetails);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/RoomsDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RoomsDetails>> PostRoomsDetails(RoomsDetails roomsDetails)
        {
            try
            {
                return await _context.PostRoomsDetails(roomsDetails);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/RoomsDetails/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRoomsDetails(int id)
        {
            try
            {
                return await _context.DeleteRoomsDetails(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }
}
