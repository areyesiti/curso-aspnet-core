using AutoMapper;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserProfileRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserProfileRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserProfileDto> GetAll()
        {
            var model = _context.UsersProfiles.ToList();
            return _mapper.Map<List<UserProfile>, List<UserProfileDto>>(model);
        }

        public UserProfileDto GetById(int profileId)
        {
            var model = _context.UsersProfiles.Find(profileId);
            if (model == null)
            {
                throw new Exception("Perfil de usuario no encontrado");
            }

            return _mapper.Map<UserProfileDto>(model);
        }
    }
}
