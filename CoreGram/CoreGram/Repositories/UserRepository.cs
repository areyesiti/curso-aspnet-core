using AutoMapper;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<UserInfoDto> GetAll()
        {
            var model = _context.Users.Include(x => x.Profile).ToList();
            var response = _mapper.Map<List<User>, List<UserInfoDto>>(model);
            return response;
        }

        public UserInfoDto GetById(int userId)
        {
            //var user = _context.Users.Find(userId);

            var user = _context.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Profile)
                .FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            var response = _mapper.Map<UserInfoDto>(user);

            return response;
        }
    }
}
