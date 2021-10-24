﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PsyPersonServer.Application.ApplicationUsers.Commands.ForgotPassword;
using PsyPersonServer.Application.ApplicationUsers.Commands.Login;
using PsyPersonServer.Application.ApplicationUsers.Commands.Register;
using PsyPersonServer.Application.ApplicationUsers.Commands.ResetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyPersonServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ApplicationUserController> _logger;
        public ApplicationUserController(IMediator mediator, ILogger<ApplicationUserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/ApplicationUser/Register
        public async Task<IActionResult> PostApplicationUser(RegisterC command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/ApplicationUser/Login
        public async Task<IActionResult> Login(LoginC command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (Exception ex)
            {
                _logger.LogError($"User Login failed {ex}", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        //POST : /api/ApplicationUser/ForgotPassword
        public async Task<IActionResult> ForgotPassword(ForgotPasswordC command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Route("ResetPassword")]
        //POST : /api/ApplicationUser/ResetPassword
        public async Task<IActionResult> ResetPassword(ResetPasswordC command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}