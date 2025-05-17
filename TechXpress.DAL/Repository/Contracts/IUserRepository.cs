using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.DAL.Repository.Contracts
{
    public interface IUserRepository:IRepository<User, int>
    {
        User GetUserByEmail(string email);
    }
  
}
