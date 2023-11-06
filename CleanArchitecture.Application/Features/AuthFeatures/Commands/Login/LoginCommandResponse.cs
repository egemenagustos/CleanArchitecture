namespace CleanArchitecture.Application.Features.AuthFeatures.Login
{
    public sealed record LoginCommandResponse(string token, string refreshToken, DateTime? refreshTokenExpires, string userId);
}
