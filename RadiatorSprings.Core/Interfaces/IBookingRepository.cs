using RadiatorSprings.Core.Entities;

namespace RadiatorSprings.Core.Interfaces;

public interface IBookingRepository
{
    Task<IReadOnlyList<Booking>> GetBookingsAsync();
    Task<Booking?> GetBookingByIdAsync(int id);
    void AddBooking(Booking booking);
}
