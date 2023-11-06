using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefeshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.AuthFeatures.Login;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterCommand registerCommand, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(registerCommand, cancellationToken);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand loginCommand, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(loginCommand, cancellationToken);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefeshTokenCommand newTokenByRefeshTokenCommand, CancellationToken cancellationToken)
        {
            LoginCommandResponse response = await _mediator.Send(newTokenByRefeshTokenCommand, cancellationToken);
            return Ok(response);
        }
    }
}
