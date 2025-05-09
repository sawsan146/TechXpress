using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;

        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
