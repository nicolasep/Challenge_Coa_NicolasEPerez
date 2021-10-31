using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.DTOs.UserDTOs;
using WebApiUsuarios.Entities;
using WebApiUsuarios.Helper.Common;
using WebApiUsuarios.Interfaces;

namespace WebApiUsuarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            
            try
            {
                var list = await _userService.GetAll();
                return (list != null) ?  new OkObjectResult(list) : new BadRequestObjectResult("No se encuentran usuarios");
                
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpGet]
        [Route(template: "{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            try
            {
                if (id <= 0) return new BadRequestObjectResult(error: "El id debe ser mayor a cero");
                var user = await _userService.GetById(id);
                return (user != null) ?  user :  new BadRequestObjectResult(error: "El id no existe");

            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromForm] UserInsertDTO userInsertDTO)
        {
            try
            {
                if(userInsertDTO == null) return new BadRequestObjectResult("Error en la carga de los datos");
                Result response = await _userService.Insert(userInsertDTO);
                return new OkObjectResult(response);
                
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPut]
        [Route(template: "{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] UserUpdateDTO userUpdateDTO)
        {
            try
            {
                if (id <= 0) return new BadRequestObjectResult(error: "El id debe ser mayor a cero");
                Result response = await _userService.Update(userUpdateDTO,id);
                return new OkObjectResult(response);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpDelete]
        [Route(template: "{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0) return new BadRequestObjectResult(error: "El id debe ser mayor a cero");
                Result response = await _userService.Delete(id);
                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
