using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class CustomerDetails
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public long MobileNo { get;set; }

        public ICollection<BookingDetail> Bookings { get; set; }=new List<BookingDetail>();

    }
}
