using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TockerTest.API.Contract.Services;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;

namespace TockerTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericServices _services;
        private readonly IValidator<VMUser> _validator;
        public UserController(IGenericServices services, IValidator<VMUser> validator)
        {
            _services = services;
            _validator = validator;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> AddUser([FromBody] VMUser data)
        {
            try
            {
                   var validator =  _validator.Validate(data);
                if (!validator.IsValid) 
                { 
                    return BadRequest(validator.Errors); 
                }

                var result =  await _services.CreateServiceAsync(data);

                Console.WriteLine($"Se a enviado un mensaje a {result.Phone}: Bienviendo!");
                return Ok(result);
            }
            catch (ArgumentException ArgEx)
            {
                return BadRequest(ArgEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
