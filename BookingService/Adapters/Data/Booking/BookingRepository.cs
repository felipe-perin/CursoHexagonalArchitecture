using Application.Ports.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Data.Booking
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _dbContext;
        public BookingRepository(HotelDbContext hotelDbContext)
        {
            _dbContext = hotelDbContext;
        }
        public async Task<int> CreateBooking(Domain.Entities.Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<int> UpdateBooking(Domain.Entities.Booking booking)
        {
            _dbContext.Entry(booking).State = EntityState.Modified;
            _dbContext.Bookings.Update(booking);
            await _dbContext.SaveChangesAsync();
            return booking.Id;
        }

    public Task<Domain.Entities.Booking> Get(int id)
        {
            return _dbContext.Bookings.Where(x => x.Id == id).FirstAsync();
        }
  }
}
