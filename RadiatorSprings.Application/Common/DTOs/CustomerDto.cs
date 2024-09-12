namespace RadiatorSprings.Application.Common.DTOs;

public record CustomerDto(
    int Id,
    string FirstName,
    string LastName,
    string DocumentType,
    string DocumentNumber,
    string PhoneNumber,
    string Email);
