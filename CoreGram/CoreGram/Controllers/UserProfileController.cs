using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data.Model;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserProfileRepository _repository;

        public UserProfileController(UserProfileRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<UserProfile>> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{profileId}")]
        public ActionResult<UserProfile> GetById(int profileId)
        {
            return _repository.GetById(profileId);
        }

    }
}