using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.Application.DTOs;

namespace TechXpress.Application.ApplicationServices.Contract
{
    public interface IContactMessageAppService
    {
     
        public void SendMessage(ContactMassegeDTO contactMassegeDTO);
    }
}
