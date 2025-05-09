using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.IService
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(User user, UserManager<User> userManager);
    }
}
