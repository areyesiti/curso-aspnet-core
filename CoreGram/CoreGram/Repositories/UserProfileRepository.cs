using CoreGram.Data;
using CoreGram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserProfileRepository
    {
        private DataContext _context;

        public UserProfileRepository(DataContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UsersProfiles.ToList();            
        }

        public UserProfile GetById(int profileId)
        {
            var model = _context.UsersProfiles.Find(profileId);
            if (model == null)
            {
                throw new Exception("Perfil de usuario no encontrado");
            }

            return model;
        }
    }
}
