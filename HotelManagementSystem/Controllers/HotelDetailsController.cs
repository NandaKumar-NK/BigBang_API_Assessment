using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Management_System.Models;
using Hotel_Management_System.Repository.BookingDetails;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Hotel_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDetailsController : ControllerBase
    {
        private readonly IHotelDetailsServices _context;

        public HotelDetailsController(IHotelDetailsServices context)
        {
            _context = context;
        }


        // GET: api/HotelDetails
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<List<HotelDetails>>> GetHotelDetails()
        {
            try
            {
                return await _context.GetHotelDetails();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        //GET: Filter Hotels Based on Location
        [HttpGet("{location}")]
      
       // [Authorize(Roles = "User")]
        public async Task<List<HotelDetails>?> FilterHotels(string location)
        {
            try
            {
                return await _context.FilterHotels(location);
            }
            catch (Exception)
            {
                return null;
            }
        }


        // PUT: api/HotelDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutHotelDetails(int id, HotelDetails hotelDetails)
        {
            


            try
            {
                return await _context.PutHotelDetails(id, hotelDetails);
            }
            catch (Exception ex)
            {
               return new BadRequestObjectResult(ex.Message);
            }

           
        }



        // POST: api/HotelDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<HotelDetails>> PostHotelDetails(HotelDetails hotelDetails)
        {
            try
            {
                return await _context.PostHotelDetails(hotelDetails);

            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        // DELETE: api/HotelDetails/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotelDetails(int id)
        {
            try
            {
                return await _context.DeleteHotelDetails(id);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);

            }
        }

        
    }
}
