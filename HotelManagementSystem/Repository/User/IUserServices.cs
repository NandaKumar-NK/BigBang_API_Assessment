using Microsoft.AspNetCore.Mvc;
using SampOnetoManyAPI.Models;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public interface IUserServices
    {
        public  Task<User> PostUser(User user);

    }
}
