using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management_System.Repository.BookingDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using SampOnetoManyAPI.Models;

namespace SampOnetoManyAPI.Controllers
{
    [Route("api/Register")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _context;

        public UsersController(IUserServices context)
        {
            _context = context;
        }


        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<User>> PostUser(User user)
        {
            return await _context.PostUser(user);
        }


    }
}
