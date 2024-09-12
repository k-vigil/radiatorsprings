using RadiatorSprings.Core.Common;
using RadiatorSprings.Core.ValueObjects;

namespace RadiatorSprings.Core.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Document Document { get; set; } = null!;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    private Customer()
    {
        
    }

    public Customer(string firstName, string lastName, Document document, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
