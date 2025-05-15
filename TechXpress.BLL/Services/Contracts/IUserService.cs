using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.Services.Contracts
{
    public interface IUserService
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
    }
}