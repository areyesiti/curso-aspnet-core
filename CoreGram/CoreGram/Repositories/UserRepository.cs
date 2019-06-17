using CoreGram.Data;
using CoreGram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetById(int userId)
        {
            var user = _context.User.Find(userId);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            return user;
        }
    }
}
