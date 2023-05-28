using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SampOnetoManyAPI.Models;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public class UserServices : IUserServices
    {

        private readonly HotelBookingDBContext _context;

        public UserServices(HotelBookingDBContext context)
        {
            _context = context;
        }
        public async Task<User> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;


        }

    }
}
