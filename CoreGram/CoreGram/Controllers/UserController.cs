using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using CoreGram.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext _context;
        UserRepository _repository;

        public UserController(DataContext context, UserRepository repository)
        {
            _context = context;
            _repository = repository;

            if (_context.Users.Count() == 0)
            {
                User user1 = new User
                {
                    Login = "Usuario1",
                    Password = "Password"
                };

                User user2 = new User
                {
                    Login = "Usuario2",
                    Password = "Password"
                };

                _context.Add(user1);
                _context.Add(user2);
                _context.SaveChanges();
            }
        }

        // GET api/users
        /// <summary>
        /// Obtiene el listado de todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<UserInfoDto>> GetAll()
        {            
            return _repository.GetAll();
        }

        /// <summary>
        /// Obtiene la información de un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserInfoDto> GetById(int id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Añade un usuario
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User item)
        {
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        /// <summary>
        /// Actualiza la información de un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFinded = await _context.Users.FindAsync(id);

            if (userFinded == null)
            {
                return NotFound();
            }

            _context.Remove(userFinded);
            await _context.SaveChangesAsync();
            return Ok(userFinded);
        }
    }
}
