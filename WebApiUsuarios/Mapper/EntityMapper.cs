using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.DTOs.UserDTOs;
using WebApiUsuarios.Entities;

namespace WebApiUsuarios.Mapper
{
    public class EntityMapper
    {
        public UserDTO FromUserToUserDto(User user)
        {
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                Nombre = user.Name,
                Email = user.Email,
                Telefono = user.PhoneNumber
            };
            return userDTO;
        }
        public User FromUserInsertDtoToUser(UserInsertDTO userInsertDTO)
        {
            var user = new User()
            {
                Name = userInsertDTO.Nombre,
                Email = userInsertDTO.Email,
                PhoneNumber = userInsertDTO.Telefono
            };
            return user;
        }
    }
}
