﻿using System;
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
    public class FollowerController : Controller
    {
        private FollowerRepository _repository;

        public FollowerController(FollowerRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Obtiene los seguidores de un usuario
        /// </summary>
        /// <param name="userId"></param>        
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<FollowerInfoDto>> GetFollowers(int userId)
        {
            return Ok(_repository.GetFollowers(userId));
        }

        /// <summary>
        /// Obtiene los usuarios que sigue un usuario
        /// </summary>
        /// <param name="userId"></param>        
        [HttpGet("Following/{userId}")]
        public ActionResult<IEnumerable<FollowerInfoDto>> GetFollowings(int userId)
        {
            return Ok(_repository.GetFollowings(userId));
        }

        /// <summary>
        /// Añade un seguidor a un usuario
        /// </summary>
        /// <param name="dto"></param>        
        [HttpPost]
        public ActionResult<FollowerDto> Create([FromBody]FollowerDto dto)
        {
            return Ok(_repository.Create(dto));
        }

        /// <summary>
        /// Elimina un seguidor de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="followerId"></param>        
        [HttpDelete("{userId}/{followerId}")]
        public ActionResult<FollowerDto> Delete(int userId, int followerId)
        {
            return Ok(_repository.Delete(userId, followerId));
        }
    }
}
