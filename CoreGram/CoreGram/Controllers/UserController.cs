using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreGram.Data;
using CoreGram.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreGram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;

            if (_context.User.Count() == 0)
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
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.User.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _context.User.Find(id);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody] User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User item)
        {
            if (id != item.Id)
            {
                throw new Exception("No coinciden los ids");
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userFinded = _context.User.Find(id);

            if (userFinded == null)
            {
                throw new Exception("El usuario no existe");
            }

            _context.Remove(userFinded);
            _context.SaveChanges();
        }
    }
}
