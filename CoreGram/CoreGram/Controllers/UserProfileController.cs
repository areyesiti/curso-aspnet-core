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
    public class UserProfileController : Controller
    {
        private UserProfileRepository _repository;

        public UserProfileController(UserProfileRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene el perfil de un usuario
        /// </summary>
        /// <param name="profileId"></param>        
        [HttpGet("{profileId}")]
        public ActionResult<IEnumerable<UserProfileDto>> GetById(int profileId)
        {
            return Ok(_repository.GetById(profileId));
        }

        /// <summary>
        /// Actualiza o crea el perfil de un usuario
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="dto"></param>        
        [HttpPut("{profileId}")]
        public ActionResult<UserProfileDto> Update(int profileId, [FromBody]UserProfileDto dto)
        {
            return Ok(_repository.Update(profileId, dto));
        }

        /// <summary>
        /// Elimina el perfil de un usuario
        /// </summary>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpDelete("{profileId}")]
        public ActionResult<UserProfileDto> Delete(int profileId)
        {
            return Ok(_repository.Delete(profileId));
        }
    }
}
