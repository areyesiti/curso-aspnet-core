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
    public class FollowerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FollowerRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<FollowerInfoDto> GetFollowers(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = _context.Followers
                .Where(x => x.UserId == userId)
                .Include(x => x.UserFollower)
                    .ThenInclude(x => x.Profile)
                .OrderBy(x => x.UserFollower.Login)
                .ToList();

            return _mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }

        public List<FollowerInfoDto> GetFollowings(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                throw new Exception("El usuario no existe");
            }

            var model = _context.Followers
                .Where(x => x.FollowerId == userId)
                .Include(x => x.UserFolling)
                    .ThenInclude(x => x.Profile)
                .OrderBy(x => x.UserFolling.Login)
                .ToList();

            return _mapper.Map<List<Follower>, List<FollowerInfoDto>>(model);
        }
    }
}
