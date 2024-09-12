using RadiatorSprings.Core.Common;

namespace RadiatorSprings.Core.Entities;

public class Booking : BaseEntity
{
    public int UserId { get; set; }
    public int VehicleId { get; set; }
    public int CustomerId { get; set; }
    public DateTime Departure { get; set; }
    public DateTime Return { get; set; }
    public decimal Total { get; set; }

    public User User { get; set; } = null!;
    public Vehicle Vehicle { get; set; } = null!;
    public Customer Customer { get; set; } = null!;

    private Booking()
    {
        
    }

    public Booking(int userId, int vehicleId, int customerId, DateTime departure, DateTime @return)
    {
        UserId = userId;
        VehicleId = vehicleId;
        CustomerId = customerId;
        Departure = departure;
        Return = @return;
    }

    public int CalculateDays()
    {
        var days = Return.Subtract(Departure).Days;

        return days;
    }

    public decimal CalculateTotal(decimal vehiclePrice)
    {
        int days = CalculateDays();

        return vehiclePrice * days;
    }
}
