using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Models;
using CoreGram.Helpers;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoreGram.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserRepository _repository;

        public UserController(UserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Autentifica un usuario
        /// </summary>
        /// <param name="auth"></param>  
        [AllowAnonymous]
        [HttpPost("Auth")]   
        public ActionResult<AuthDto> Authenticate([FromBody]LoginDto auth)
        {
            return Ok(_repository.Authenticate(auth));
        }

        /// <summary>
        /// Registra un usuario
        /// </summary>
        /// <param name="dto"></param>   
        [AllowAnonymous]
        [HttpPost("Register")]
        public ActionResult<UserInfoDto> Register([FromBody]UserDto dto)
        {
            return Ok(_repository.Create(dto));
        }


        /// <summary>
        /// Obtiene el listado de todos los usuarios
        /// </summary>
        [HttpGet]        
        public ActionResult<IEnumerable<UserInfoDto>> GetAll()
        {            
            return Ok(_repository.GetAll());
        }

        /// <summary>
        /// Obtiene la información de un usuario
        /// </summary>
        /// <param name="userId"></param> 
        [HttpGet("{userId}")]
        public ActionResult<UserInfoDto> GetById(int userId)
        {            
            return Ok(_repository.GetById(userId));
        }

        /// <summary>
        /// Actualiza la información de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dto"></param>   
        [HttpPut("{userId}")]
        public ActionResult<UserInfoDto> Update(int userId, [FromBody]UserDto dto)
        {
            return Ok(_repository.Update(userId, dto));
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="userId"></param>
        [HttpDelete("{userId}")]
        public ActionResult<UserInfoDto> Delete(int userId)
        {            
            return Ok(_repository.Delete(userId));
        }
    }
}
