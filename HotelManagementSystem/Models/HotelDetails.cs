using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class HotelDetails
    {
        [Key]
        public int HotelId { get; set; }

        public string HotelName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int TotalRooms { get; set; }
        public ICollection<RoomsDetails> Rooms { get; set; }=new List<RoomsDetails>();
        public ICollection<BookingDetail> Bookings { get; set; } = new List<BookingDetail>();
    }
}
