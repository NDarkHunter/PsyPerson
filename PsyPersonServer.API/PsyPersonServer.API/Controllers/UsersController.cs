﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsyPersonServer.Application.Users.Commands.CreateUser;
using PsyPersonServer.Application.Users.Commands.UpdateUser;
using PsyPersonServer.Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyPersonServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
        [HttpGet]
        [Route("GetAll")]
        //Get : /api/Users/GetAll
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQ query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateUser")]
        //PUT : /api/Users/UpdateUser
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserC command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Authorize]
        [Route("CreateUser")]
        //POST : /api/Users/UpdateUser
        public async Task<IActionResult> CreateUser([FromBody] CreateUserC command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
