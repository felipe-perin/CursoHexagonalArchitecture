using Entities = Domain.Entities;

namespace Application.Ports.Infrastructure
{
    public interface IBookingRepository
    {
        Task<Entities.Booking> Get(int id);
        Task<int> CreateBooking(Entities.Booking booking);
        Task<int> UpdateBooking(Entities.Booking booking);
    }
}
