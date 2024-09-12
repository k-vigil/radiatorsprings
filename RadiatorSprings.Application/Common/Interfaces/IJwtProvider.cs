namespace RadiatorSprings.Application.Common.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(int userId);
}
