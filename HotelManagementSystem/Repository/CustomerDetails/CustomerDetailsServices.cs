using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public class CustomerDetailsServices: ICustomerDetailsServices
    {

        private readonly HotelBookingDBContext _context;

        public CustomerDetailsServices(HotelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails()
        {
            return await _context.CustomerDetails.ToListAsync();
        }

        public async Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id)
        {

            var Cid = await _context.CustomerDetails.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (Cid is null)
            {
                return null;
            }
            return Cid;
        }

        public async Task<IActionResult> PutCustomerDetails(int id, CustomerDetails customerDetails)
        {

            

            var Cid = await _context.CustomerDetails.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (Cid is null)
            {
                return null;
            }
            Cid.MobileNo = customerDetails.MobileNo;
            Cid.CustomerEmail = customerDetails.CustomerEmail;
            Cid.CustomerName = customerDetails.CustomerName;
            await _context.SaveChangesAsync();
            return (IActionResult)Cid;
        }

        public async Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails)
        {
            await _context.CustomerDetails.AddAsync(customerDetails);
            _context.SaveChangesAsync();
            return customerDetails;
        }


        public async Task<IActionResult> DeleteCustomerDetails(int id)
        {
            var Cid = await _context.CustomerDetails.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (Cid is null)
            {
                return null;
            }
            _context.Remove(Cid);
            await _context.SaveChangesAsync();
            return (IActionResult)Cid;
        }


    }
}
