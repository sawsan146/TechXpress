using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using System.Security.Claims; 

namespace TechXpress.Application.ApplicationServices.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserAppService(IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(userDTO), "User cannot be null");
            }
            else
            {
                _userService.Add(user);
            }
            return userDTO;
        }

        public void DeleteUser(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            else
            {
                _userService.Delete(id);
            }
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            //if (user == null)
            //{
            //    throw new ArgumentNullException(nameof(user), "User  cannot be null");
            //}
           
            
                var userDto= _mapper.Map<UserDTO>(user);
                return userDto;

            
        }

        public UserDTO GetUserById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }
            else
            {
                var userDto = _mapper.Map<UserDTO>(user);
                return userDto;
            }
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(userDTO), "User cannot be null");
            }
            else
            {
                _userService.Update(user);
            }

        }

        public UserDTO GetCurrentUser()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged in.");

            var user = _userService.GetById(int.Parse(userId)); 
            return _mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetAllUsers()
        {
            var users = _userService.GetAll();
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users), "Users cannot be null");
            }
            else
            {
                var userDtos = _mapper.Map<List<UserDTO>>(users);
                return userDtos;
            }

        }

    }
}
