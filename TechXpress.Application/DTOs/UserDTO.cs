using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class UserDTO
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string User_Type { get; set; }

        public string? Country { get; set; } = "Egypt";
    }
}
