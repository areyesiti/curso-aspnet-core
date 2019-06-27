using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly FollowerRepository _repository;

        public FollowerController(FollowerRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("{userId}")]
        public ActionResult<List<FollowerInfoDto>> GetFollowers(int userId)
        {
            return _repository.GetFollowers(userId);
        }

        [HttpGet("Folloging/{userId}")]
        public ActionResult<List<FollowerInfoDto>> GetFollowings(int userId)
        {
            return _repository.GetFollowings(userId);
        }

    }
}