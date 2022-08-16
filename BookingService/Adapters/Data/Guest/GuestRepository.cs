using Application.Ports.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Entities = Domain.Entities;

namespace Data.Guest
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public GuestRepository(HotelDbContext hotelDbContext)
        { 
            _hotelDbContext = hotelDbContext;
        }
        public async Task<int> Create(Entities.Guest guest)
        {
            _hotelDbContext.Guests.Add(guest);
            await _hotelDbContext.SaveChangesAsync();
            return guest.Id;
        }

        public Task<Entities.Guest> Get(int Id)
        {
            return _hotelDbContext.Guests.FirstOrDefaultAsync(g => g.Id == Id);
        }
    }
}
