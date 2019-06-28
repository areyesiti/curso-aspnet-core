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
    public class CommentController : Controller
    {
        private CommentRepository _repository;

        public CommentController(CommentRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtiene todos los comentarios de un post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet("{postId}")]
        public ActionResult<CommentDto> GetByPost(int postId)
        {
            return Ok(_repository.GetByPost(postId));
        }

        /// <summary>
        /// Crea un comentario asociado a un post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<CommentDto> Create([FromBody]CommentDto dto)
        {
            return Ok(_repository.Comment(dto));
        }

        /// <summary>
        /// Elimina un comentario asociado a un post
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        [HttpDelete("{commentId}")]
        public ActionResult<CommentDto> Delete(int commentId)
        {
            return Ok(_repository.Delete(commentId));
        }
    }
}
