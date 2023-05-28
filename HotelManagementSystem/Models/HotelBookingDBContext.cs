
using System;
using System.Collections.Generic;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampOnetoManyAPI.Models;

public partial class HotelBookingDBContext  :IdentityDbContext<IdentityUser>
{
    public HotelBookingDBContext()
    {
    }

    public HotelBookingDBContext(DbContextOptions<HotelBookingDBContext> options)
        : base(options)
    {
    }
    public DbSet<BookingDetail> Bookings { get; set; }
    public DbSet<CustomerDetails> CustomerDetails { get; set; }
    public DbSet<HotelDetails> HotelDetails { get; set; }
   
    public DbSet<RoomsDetails> RoomsDetails { get; set; }
    public DbSet<User> Users { get; set; }


}