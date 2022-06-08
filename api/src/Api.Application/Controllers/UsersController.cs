using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException exception)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(Id));
            }
            catch (ArgumentException exception)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Post(user));
            }
            catch (ArgumentException exception)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
