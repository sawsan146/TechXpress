using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IUserAppService
    {
        public UserDTO AddUser(UserDTO userDTO);
        public void UpdateUser(UserDTO userDTO);
        public void DeleteUser(int id);
        public UserDTO GetUserById(int id);
        public List<UserDTO> GetAllUsers();

        // public List<UserDTO> GetUsersByRole(string role);

        public UserDTO GetUserByEmail(string email);
        public UserDTO GetCurrentUser();


    }
}
