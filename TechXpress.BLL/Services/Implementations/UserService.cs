using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;

namespace TechXpress.BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, int> _userRepository;

        public UserService(IRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}