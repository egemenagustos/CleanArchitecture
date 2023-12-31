﻿using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole
{
    public record CreateRoleCommand(string name) : IRequest<MessageResponse>;
}
