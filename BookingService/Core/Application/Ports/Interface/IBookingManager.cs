using Application.Booking;
using Application.Booking.Dtos;
using Application.Payment.Responses;

namespace Application.Ports.Interface
{
    public interface IBookingManager
    {
        Task<BookingResponse> SaveBooking(BookingDto booking);
        Task<PaymentResponse> PayForABooking(PaymentRequestDto paymentRequestDto);
        Task<BookingDto> GetBooking(int id);
    }
}
