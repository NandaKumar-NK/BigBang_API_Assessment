using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Hotel_Management_System.Repository.BookingDetails;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBookingDetailsServices _context;

        public BookingDetailsController(IBookingDetailsServices context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookings()
        {
            try
            {
                return await _context.GetBookings();

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<BookingDetail>> GetBookingDetails(int id)
        {
            try
            {
                return await _context.GetBookingDetails(id);

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        // PUT: api/BookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       [Authorize(Roles = "User")]
        public async Task<IActionResult> PutBookingDetails(int id, BookingDetail bookingDetails)
        {
            try
            {
                return await _context.PutBookingDetails(id, bookingDetails);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);  
            }
        }

        // POST: api/BookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<BookingDetail>> PostBookingDetails(BookingDetail bookingDetails)
        {
            try
            {
                return await _context.PostBookingDetails(bookingDetails);

            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteBookingDetails(int id)
        {
            try
            {
                return await _context.DeleteBookingDetails(id);


            }
            catch(Exception ex) { 
            return new BadRequestObjectResult(ex);
            }
        }

      
    }
}
