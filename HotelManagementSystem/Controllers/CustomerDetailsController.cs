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
    public class CustomerDetailsController : ControllerBase
    {
        private readonly ICustomerDetailsServices _context;

        public CustomerDetailsController(ICustomerDetailsServices context)
        {
            _context = context;
        }

        // GET: api/CustomerDetails
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()
        {
            try
            {
                return await _context.GetCustomerDetails();

            }
            catch(Exception ex) { 
            return BadRequest(ex.Message);
            }
        }

        // GET: api/CustomerDetails/5
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id)
        {

            try
            {
                return await _context.GetCustomerDetails(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/CustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> PutCustomerDetails(int id, CustomerDetails customerDetails)
        {
            try
            {
                return await _context.PutCustomerDetails(id, customerDetails);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/CustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            try
            {
                return await _context.PostCustomerDetails(customerDetails);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // DELETE: api/CustomerDetails/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteCustomerDetails(int id)
        {
            try
            {
                return await _context.DeleteCustomerDetails(id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

       
    }
}
