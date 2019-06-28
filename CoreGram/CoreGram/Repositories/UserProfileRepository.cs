using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreGram.Data;
using CoreGram.Data.Dto;
using CoreGram.Data.Models;
using CoreGram.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CoreGram.Repositories
{
    public class UserProfileRepository
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public UserProfileRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UserProfileDto GetById(int profileId)
        {
            // Obtenemos el perfil de usuario y comprobamos si existe
            var model = _context.UsersProfiles.Find(profileId);
            if (model == null)
            {
                throw new NotFoundException("Perfil de usuario no encontrado");
            }

            // Mapeamos y enviamos la respuesta
            var response = _mapper.Map<UserProfileDto>(model);
            return response;
        }

        public UserProfileDto Update(int profileId, UserProfileDto dto)
        {
            UserProfile model;

            // Comprobamos si viene vacía la propiedad Id del dto,
            // si es así le asignamos el id de los parámetros.
            if (dto.Id == 0) dto.Id = profileId;

            // Recuperamos el usuario y comprobamos si existe
            var user = _context.Users.Find(dto.Id);
            if (user == null)
            {
                throw new NotFoundException("Usuario no encontrado");
            }

            // Recuperamos el perfil de usuario y comprobamos si existe
            var profile = _context.UsersProfiles.Find(profileId);
            if (profile == null)
            {
                // Si no existe creamos uno nuevo y lo añadimos al contexto
                model = _mapper.Map<UserProfile>(dto);
                _context.UsersProfiles.Add(model);                
                
            } else
            {                
                // Para corregir el error que salía durante el curso, ponemos profile con estado detached
                _context.Entry(profile).State = EntityState.Detached;

                // Si existe lo actualizamos con los nuevos datos
                model = _mapper.Map<UserProfile>(dto);
                _context.UsersProfiles.Update(model);                
            }

            // Guardamos y devolvemos la respuesta mapeada
            _context.SaveChanges();
            var response = _mapper.Map<UserProfileDto>(model);
            return response;
        }
        public UserProfileDto Delete(int profileId)
        {
            // Obtenemos el perfil de usuario y comprobamos si existe
            var model = _context.UsersProfiles.Find(profileId);

            if (model == null)
            {
                throw new NotFoundException("No se ha encontrado el perfil de usuario");
            }

            // Eliminamos el perfil del contexto, guardamos y devolvemos la respuesta mapeada
            _context.UsersProfiles.Remove(model);
            _context.SaveChanges();
            var response = _mapper.Map<UserProfileDto>(model);
            return response;
        }
    }
}
