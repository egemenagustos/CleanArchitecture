using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class RoleController : ApiController
    {
        public RoleController(IMediator mediator) : base(mediator){}

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateRoleCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
