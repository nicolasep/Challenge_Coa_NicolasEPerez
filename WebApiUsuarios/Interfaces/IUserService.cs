using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.DTOs.UserDTOs;
using WebApiUsuarios.Helper.Common;

namespace WebApiUsuarios.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<Result> Insert(UserInsertDTO userInsertDTO);
        Task<Result> Update(UserUpdateDTO userUpdateDTO, int id);
        Task<Result> Delete(int id);

    }
}
