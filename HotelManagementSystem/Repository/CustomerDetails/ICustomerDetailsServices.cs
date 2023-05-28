using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Repository.BookingDetails
{
    public interface ICustomerDetailsServices
    {
        public Task<ActionResult<IEnumerable<CustomerDetails>>> GetCustomerDetails();
        public Task<ActionResult<CustomerDetails>> GetCustomerDetails(int id);
        public  Task<IActionResult> PutCustomerDetails(int id, CustomerDetails customerDetails);
        public Task<ActionResult<CustomerDetails>> PostCustomerDetails(CustomerDetails customerDetails);

        public Task<IActionResult> DeleteCustomerDetails(int id);



    }
}
