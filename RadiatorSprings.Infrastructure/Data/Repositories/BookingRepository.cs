namespace RadiatorSprings.Infrastructure.Data.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddBooking(Booking booking) =>
        _context.Bookings.Add(booking);

    public async Task<Booking?> GetBookingByIdAsync(int id) =>
        await _context.Bookings
            .Include(b => b.Customer)
            .Include(b => b.Vehicle)
            .SingleOrDefaultAsync(b => b.Id == id);

    public async Task<IReadOnlyList<Booking>> GetBookingsAsync() =>
        await _context.Bookings
            .AsNoTracking()
            .Include(b => b.Customer)
            .Include(b => b.Vehicle)
            .ToListAsync();
}
