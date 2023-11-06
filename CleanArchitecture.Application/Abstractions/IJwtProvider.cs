using CleanArchitecture.Application.Features.AuthFeatures.Login;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Abstractions
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateTokenAsync(User user);
    }
}
