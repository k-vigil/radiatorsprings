namespace RadiatorSprings.Application.Common.DTOs;

public record BookingDto(
    int Id,
    string Departure,
    string Return,
    string Customer,
    string Vehicle);
