using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Entities;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        /*[HttpGet, ActionName("GetByName")]
        public async Task<ActionResult> GetByName(string name)
        {
            try
            {
                return Ok(await _service.GetByName(name));
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }*/

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userDto = await _service.Get(id);

                if (userDto == null)
                {
                    return NotFound();
                }

                return Ok(userDto);
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
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
                var result = await _service.Post(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ae)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ae.Message);
            }
        }
    }
}