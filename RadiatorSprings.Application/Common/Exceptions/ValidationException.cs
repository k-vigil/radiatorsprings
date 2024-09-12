namespace RadiatorSprings.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; set; }

    public ValidationException()
        : base("One or more validation errors")
    {
        Errors = new List<string>();
    }

    public ValidationException(List<string> errors)
        : this()
    {
        Errors = errors;
    }
}
