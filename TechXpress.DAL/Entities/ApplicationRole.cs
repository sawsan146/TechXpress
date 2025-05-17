using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {


        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }

      
    }
}

