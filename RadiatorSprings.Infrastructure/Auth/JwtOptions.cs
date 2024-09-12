namespace RadiatorSprings.Infrastructure.Auth;

public record JwtOptions
{
    public string Audience { get; set; } = "";
    public string Issuer { get; set; } = "";
    public string SecretKey { get; set; } = "";
}
