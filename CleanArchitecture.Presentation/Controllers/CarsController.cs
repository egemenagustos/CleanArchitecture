using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Commands.UpdateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class CarsController : ApiController
    {
        public CarsController(IMediator mediator) : base(mediator) { }

        //[TypeFilter(typeof(RoleAttribute), Arguments = new Object[] {"Create"})]
        [RoleFilter("Create")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        //[TypeFilter(typeof(RoleAttribute), Arguments = new Object[] {"Create"})]
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [RoleFilter("GetAll")]
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllCarQuery getAllCarQuery, CancellationToken cancellationToken)
        {
            List<Car> cars = await _mediator.Send(getAllCarQuery);
            return Ok(cars);
        }
    }
}
