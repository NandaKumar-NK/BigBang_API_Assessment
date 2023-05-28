using Hotel_Management_System.Models;
using Hotel_Management_System.Repository.BookingDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        //dependency Injection

      builder.Services.AddScoped<IBookingDetailsServices, BookingDetailsServices>();
        builder.Services.AddScoped<ICustomerDetailsServices, CustomerDetailsServices>();
        builder.Services.AddScoped<IHotelDetailsServices, HotelDetailsServices>();
        builder.Services.AddScoped<IRoomsDetailsServices, RoomsDetailsServices>();
        builder.Services.AddScoped<IUserServices, UserServices>();

        builder.Services.AddDbContext<HotelBookingDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));


        // Adding Authentication
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });
        //builder.Services.AddScoped<IProductRepository, ProductRepository>();


        // Adding Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })

        // Adding Jwt Bearer
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWT:Audience"],
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
            };
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}