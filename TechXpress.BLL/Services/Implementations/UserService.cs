using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.BLL.Services.Contracts;
using TechXpress.DAL.Entities;
using TechXpress.DAL.Repository.Contracts;
using TechXpress.DAL.Repository.Implementations;
using TechXpress.DAL.UnitOfWork;

namespace TechXpress.BLL.Services.Implementations
{
    public class UserService :Service<User,int>, IUserService
    {

        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork, ILogger<UserService> logger)
            : base(repository, unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
        }



        public User GetUserByEmail(string email)
        {
            var user = _unitOfWork.Users.GetUserByEmail(email);
            //if (user == null)
            //{
            //    throw new Exception("User not found");
            //}
            return user;
        }


    }
}