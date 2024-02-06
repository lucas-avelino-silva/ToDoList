namespace Infra.CrossCutting;

public interface ITokenService
{
    string GenerateToken(string user);
}
