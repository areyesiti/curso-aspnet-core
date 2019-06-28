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
    public class PostController : Controller
    {
        private PostRepository _repository;

        public PostController(PostRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene todos los post
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<PostInfoDto>> GetAll()
        {
            return Ok(_repository.GetAll());
        }
        
        /// <summary>
        /// Obtiene los post de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<PostInfoDto>> GetByUser(int userId)
        {
            return Ok(_repository.GetByUser(userId));
        }

        /// <summary>
        /// Obtiene los post de los usuarios a los que sigue un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("Followings/{userId}")]
        public ActionResult<IEnumerable<PostInfoDto>> GetByFollowings(int userId)
        {
            return Ok(_repository.GetByFollowings(userId));
        }


        /// <summary>
        /// Crea un post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<PostDto> Create([FromBody]PostDto dto)
        {
            return Ok(_repository.Create(dto));
        }

        /// <summary>
        /// Elimina un post
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public ActionResult<PostDto> Delete(int userId)
        {
            return Ok(_repository.Delete(userId));
        }
    }
}
