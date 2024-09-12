namespace RadiatorSprings.Application.Common.DTOs;

public record VehicleDto(
    int Id,
    string Description,
    string? UrlImage,
    decimal Price,
    bool Active,
    string Category);
