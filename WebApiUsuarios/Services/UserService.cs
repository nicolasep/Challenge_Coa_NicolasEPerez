using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.DTOs.UserDTOs;
using WebApiUsuarios.Helper.Common;
using WebApiUsuarios.Infrastructure.Repositories.IRepositories;
using WebApiUsuarios.Interfaces;
using WebApiUsuarios.Mapper;

namespace WebApiUsuarios.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EntityMapper _mapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new EntityMapper();
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var request = await _unitOfWork.UsersRepository.GetAll();

            return request.Select(x => _mapper.FromUserToUserDto(x)).ToList();
        }
        public async Task<UserDTO> GetById(int id)
        {
            var user = await _unitOfWork.UsersRepository.GetById(id);
           
            return (user != null) ? _mapper.FromUserToUserDto(user) : null;
        }
        public async Task<Result> Insert(UserInsertDTO userInsertDTO)
        {
            var newUser = _mapper.FromUserInsertDtoToUser(userInsertDTO);
            if (newUser == null) return new Result().Fail("Ocurrio un error al agregar el usuario");

            await _unitOfWork.UsersRepository.Insert(newUser);
            await _unitOfWork.SaveChangesAsync();
            return new Result().Success("Usuario creado con exito");
        }
        public async Task<Result> Update(UserUpdateDTO userUpdateDTO, int id)
        {
            var user = await _unitOfWork.UsersRepository.GetById(id);
            if (user == null) return new Result().Fail("Usuario inexistente");

            if (userUpdateDTO.Nombre != null) user.Name = userUpdateDTO.Nombre;
            if (userUpdateDTO.Email != null) user.Email = userUpdateDTO.Email;
            if (userUpdateDTO.Telefono != null) user.PhoneNumber = userUpdateDTO.Telefono;

            await _unitOfWork.UsersRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return new Result().Success("Usuario modificado con exito");
        }
        public async Task<Result> Delete(int id)
        {
            var user = await _unitOfWork.UsersRepository.GetById(id);
            if (user == null) return new Result().Fail("Usuario inexistente");

            await _unitOfWork.UsersRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return new Result().Success("Usuario eliminado con exito");
        }
    }
}
