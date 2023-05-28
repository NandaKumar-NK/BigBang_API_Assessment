using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models
{
    public class RoomsDetails
    {
        [Key]
        public int RoomNo { get; set; }

        public HotelDetails? HotelId { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public bool RoomAvailability { get; set; }
        public DateTime Date {  get; set; }
        public int Price { get; set; }
        public ICollection<BookingDetail> Bookings { get; set; } = new List<BookingDetail>();


    }
}
