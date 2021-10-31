using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsuarios.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }
    }
}
