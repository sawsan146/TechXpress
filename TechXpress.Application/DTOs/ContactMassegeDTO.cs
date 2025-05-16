using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class ContactMassegeDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
